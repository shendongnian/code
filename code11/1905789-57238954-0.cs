    using Newtonsoft.Json;
    using System;
    
    namespace ConsoleApp3
    {
        class Program
        {
            static void Main(string[] args)
            {
                var y = JsonConvert.DeserializeObject<ContentModel>("{\"Message\":\"asdf\",\"Attachments\":[\"dummy.pdf\",\"unnamed.jpg\"]}");
                Console.WriteLine(JsonConvert.SerializeObject(y, Formatting.Indented));
    
                Console.ReadKey();
            }
        }
    
        public class ContentModel
        {
            public string Message { get; set; }
            public string ContentType { get; set; }
            public string[] Attachments { get; set; }
        }
    }
