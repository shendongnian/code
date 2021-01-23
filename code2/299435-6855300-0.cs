    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dict = new JavaScriptSerializer().Deserialize<Dictionary<string,int>>("{ a: 1, b: 2 }");
                Console.WriteLine(dict["a"]);
                Console.WriteLine(dict["b"]);
                Console.ReadLine();
            }
        }
    }
