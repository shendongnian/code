    using System;
    using System.IO;
    using Newtonsoft.Json.Linq;
    
    namespace EvalTest
    {
      public class Test
      {
        static void Main(string [] args)
        {
            string text = File.ReadAllText("test.txt");
            var json = JObject.Parse(text);
            
            var data = json["data"];
            Console.WriteLine((string) data[0]["id"]);
        }
      }
    }
