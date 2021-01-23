    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    namespace ConsoleApplication1
    {
        public class MyClass
        {
            public static void Main(string[] args)
            {
                string inputString = @"
                    [
                        {
                            ""id"": 19019,
                            ""model"": ""tester"",
                            ""fields"":
                            {
                                ""name"": ""thename"",
                                ""slot"": 45,
                                ""category"": ""thecategory""
                            }
                        }
                    ]
                ";
                var root = JsonConvert.DeserializeObject<RootObject[]>(inputString);
                foreach (var item in root)
                {
                    Console.WriteLine(item.id + " " + item.model + " " + item.fields.name + " " + item.fields.category);
                }
            }
        }
        public class RootObject
        {
            public int id { get; set; }
            public string model { get; set; }
            public Item fields { get; set; }
        }
        public class Item
        {
            public string name { get; set; }
            public int slot { get; set; }
            public string category { get; set; }
        }
    }
