    using System;
    using System.IO;
    using Newtonsoft.Json;
    
    class Target
    {
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            JsonSerializer serializer = new JsonSerializer();
            string json = File.ReadAllText(@"c:\temp\json.txt");
            using (JsonReader reader = new JsonTextReader(new StringReader(json)))
            {
                Target target = serializer.Deserialize<Target>(reader);
            }
        }
    }
