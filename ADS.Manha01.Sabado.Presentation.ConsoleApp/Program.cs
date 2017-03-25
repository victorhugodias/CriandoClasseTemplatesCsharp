using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Manha01.Sabado.Presentation.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathEntidade = @"C:\Users\Administrador\Documents\visual studio 2015\Projects\ADS.Manha01.Sabado.Solution\ADS.Manha01.Sabado.Presentation.ConsoleApp\Templates\Entidade.txt";

            var pathIRepository = @"C:\Users\Administrador\Documents\visual studio 2015\Projects\ADS.Manha01.Sabado.Solution\ADS.Manha01.Sabado.Presentation.ConsoleApp\Templates\IRepository.txt";

            var pathDestinho = @"C:\Users\Administrador\Documents\visual studio 2015\Projects\ADS.Manha01.Sabado.Solution\ADS.Manha01.Sabado.Presentation.ConsoleApp\Templates\";

            var nomeNamespaceRaiz = "ADS.Manha01.Sabado";
            var nomeCamada = ".Presentation";
            var nomeApp = ".ConsoleApp";

            var listaDeUsings = "using System;\r\nusing System.Collections.Generic;\r\nusing ADS.Manha01.Sabado.Presentation.ConsoleApp.Templates;\r\n";

            var conteudoLido = File.ReadAllText(pathEntidade);

            string[] listaDeEntidades = new string[] {
                "Autor",
                "Blog",
                "Postagem",
                "Comentario",
                "Tag"
            };
            string listaDePropriedades;
            string retorno;

            foreach (var nomeEntidade in listaDeEntidades)
            {
                listaDePropriedades = "public Guid " + nomeEntidade + "Id { get; set; }";

                retorno = conteudoLido.Replace("{{ListaDeUsings}}", listaDeUsings)
                                    .Replace("{{NomeNamespaceRaiz}}", nomeNamespaceRaiz)
                                    .Replace("{{NomeCamada}}", nomeCamada)
                                    .Replace("{{NomeApp}}", nomeApp)
                                    .Replace("{{NomeEntidade}}", nomeEntidade)
                                    .Replace("{{ListaDePropriedades}}", listaDePropriedades);

                File.WriteAllText(pathDestinho + nomeEntidade + ".cs", retorno);
                Console.WriteLine(retorno);
                Console.WriteLine("------------------------------------------------");
            }

            conteudoLido = File.ReadAllText(pathIRepository);
            foreach (var nomeEntidade in listaDeEntidades)
            {
                retorno = conteudoLido.Replace("{{ListaDeUsings}}", listaDeUsings)
                                    .Replace("{{NomeNamespaceRaiz}}", nomeNamespaceRaiz)
                                    .Replace("{{NomeCamada}}", nomeCamada)
                                    .Replace("{{NomeApp}}", nomeApp)
                                    .Replace("{{NomeEntidade}}", nomeEntidade);

                File.WriteAllText(pathDestinho + "I" + nomeEntidade + "Repository.cs", retorno);

                Console.WriteLine(retorno);
                Console.WriteLine("------------------------------------------------");
            }

            Console.ReadLine();
        }
    }
}
