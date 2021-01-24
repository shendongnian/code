    using System;
    using Newtonsoft.Json;
    using System.IO;
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
              //File with json
              string jsontext = File.ReadAllText("json.json");
              dynamic json = JsonConvert.DeserializeObject(jsontext);
              foreach(var parameter in json.parameters)
              {
                Console.WriteLine(parameter.D);
                Console.WriteLine(parameter.E);
                Console.WriteLine(parameter.F);
              }
              Console.ReadLine();
            }
        }
    }
