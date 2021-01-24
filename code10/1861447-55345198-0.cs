    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    namespace JsonParse
    {
        class Program
        {
            static void Main(string[] args)
            {
                string json = @"{
                    CPU: 'Intel',
                    Drives: [
                        'DVD read/writer',
                        '500 gigabyte hard drive'
                    ]
                    }";
                JObject o = JObject.Parse(json);
                foreach (var prop in o.Properties())
                {
                    Console.WriteLine(prop.Name);
                }
            }
        }
    }
