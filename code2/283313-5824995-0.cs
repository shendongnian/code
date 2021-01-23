    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;
    
    public class SomeModel
    {
        public string Mode { get; set; }
        public IEnumerable<Element> Elements { get; set; }
    }
    
    public class Element
    {
        public string Name { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var json =
    @"{
        ""Mode"":""And"",
        ""Elements"":
        [
            {
                ""Name"":""ID"",
                ""Operator"":""Equal"",
                ""Value"":""3""
            }
        ]
    }";
            var serializer = new DataContractJsonSerializer(typeof(SomeModel));
            using (var stream = new MemoryStream(Encoding.Default.GetBytes(json)))
            {
                var model = (SomeModel)serializer.ReadObject(stream);
                Console.WriteLine(model.Mode);
                foreach (var element in model.Elements)
                {
                    Console.WriteLine(element.Name);
                    Console.WriteLine(element.Operator);
                    Console.WriteLine(element.Value);
                }
            }
        }
    }
