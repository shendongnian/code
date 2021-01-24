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
                string myObject = MyDeserializer.PopulateObject(new[] { st1, st2 } );
    
                Console.WriteLine(myObject);
                Console.ReadLine();
    
            }
        }
    
        public class MyDeserializer
        {
        public static string PopulateObject(string[] jsonStrings)
        {
            Dictionary<string, object> fullEntity = new Dictionary<string, object>();
            if (jsonStrings != null && jsonStrings.Length > 0)
            {
                for (int i = 0; i < jsonStrings.Length; i++)
                {
                    
                    var myEntity = JsonSerializer.Parse<Dictionary<string, object>>(jsonStrings[i]);
                    foreach (var key in myEntity.Keys)
                    {
                        if (!fullEntity.ContainsKey(key))
                        {
                            fullEntity.Add(key, myEntity[key]);
                        }
                        else
                        {
                            fullEntity[key] = myEntity[key];
                        }
                    }
                }
            }
                return JsonSerializer.ToString(fullEntity);
          }
        }
    }
