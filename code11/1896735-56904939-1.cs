    using System;
    using System.Text.Json;
    using System.IO;
    using System.Text.Json.Serialization;
    
    namespace JsonQuestion1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Only used for testing
                string path = @"C:\Users\Path\To\JsonFiles";
                string st1 = File.ReadAllText(path + @"\st1.json");
                string st2 = File.ReadAllText(path + @"\st2.json");
                // Only used for testing ^^^
                MyClass myObject = MyDeserializer.PopulateObject<MyClass>(new[] { st1, st2 } );
    
                Console.WriteLine(myObject.Head + " " + myObject.Link + " " + myObject.Title);
                Console.ReadLine();
    
            }
        }
    
        public class MyDeserializer
        {
            public static TEntity PopulateObject<TEntity>(string[] jsonStrings)
            {
                TEntity entity = default(TEntity);
    
                if (jsonStrings != null && jsonStrings.Length > 0)
                {
                    for (int i = 0; i < jsonStrings.Length; i++)
                    {
                        entity = JsonSerializer.Parse<TEntity>(jsonStrings[i]);
                    }
                }
    
                return entity;
            }
        }
    
        class MyClass
        {
            public string Title { get; set; }
            public string Head { get; set; }
            public string Link { get; set; }
    
        }
    }
