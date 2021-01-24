    using System;
    using System.Linq;
    using System.Text.Json.Serialization;
    
    namespace ConsoleApp
    {
        public class Model
        {
            public string Title { get; set; }
            public string Head { get; set; }
            public string Link { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var model = new Model();
    
                Console.WriteLine(JsonSerializer.ToString(model));
    
                var json1 = "{ \"Title\": \"Startpage\", \"Link\": \"/index\" }";
    
                Map<Model>(model, json1);
    
                Console.WriteLine(JsonSerializer.ToString(model));
    
                var json2 = "{ \"Head\": \"Latest news\", \"Link\": \"/news\" }";
    
                Map<Model>(model, json2);
    
                Console.WriteLine(JsonSerializer.ToString(model));
    
                Console.ReadKey();
            }
    
            private static T Map<T>(T obj, string jsonString) where T : class
            {
                var newObj = JsonSerializer.Parse<T>(jsonString);
    
                foreach (var property in newObj.GetType().GetProperties())
                {
                    if (obj.GetType().GetProperties().Any(x => x.Name == property.Name && property.GetValue(newObj) != null))
                    {
                        property.SetValue(obj, property.GetValue(newObj));
                    }
                }
    
                return obj;
            }
        }
    }
