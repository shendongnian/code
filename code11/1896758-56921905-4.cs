    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text.Json.Serialization;
    
    namespace ConsoleApp
    {
        public class Model
        {
            public Model()
            {
                SubModel = new SubModel();
            }
    
            public string Title { get; set; }
            public string Head { get; set; }
            public string Link { get; set; }
            public SubModel SubModel { get; set; }
        }
    
        public class SubModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var model = new Model();
    
                Console.WriteLine(JsonSerializer.ToString(model));
    
                var json1 = "{ \"Title\": \"Startpage\", \"Link\": \"/index\" }";
    
                model = Map<Model>(model, json1);
    
                Console.WriteLine(JsonSerializer.ToString(model));
    
                var json2 = "{ \"Head\": \"Latest news\", \"Link\": \"/news\", \"SubModel\": { \"Name\": \"Reyan Chougle\" } }";
    
                model = Map<Model>(model, json2);
    
                Console.WriteLine(JsonSerializer.ToString(model));
    
                var json3 = "{ \"Head\": \"Latest news\", \"Link\": \"/news\", \"SubModel\": { \"Description\": \"I am a Software Engineer\" } }";
    
                model = Map<Model>(model, json3);
    
                Console.WriteLine(JsonSerializer.ToString(model));
    
                var json4 = "{ \"Head\": \"Latest news\", \"Link\": \"/news\", \"SubModel\": { \"Description\": \"I am a Software Programmer\" } }";
    
                model = Map<Model>(model, json4);
    
                Console.WriteLine(JsonSerializer.ToString(model));
    
                Console.ReadKey();
            }
    
            public static T Map<T>(T obj, string jsonString) where T : class
            {
                var newObj = JsonSerializer.Parse<T>(jsonString);
    
                foreach (var property in newObj.GetType().GetProperties())
                {
                    if (obj.GetType().GetProperties().Any(x => x.Name == property.Name && property.GetValue(newObj) != null))
                    {
                        if (property.GetType().IsClass && property.PropertyType.Assembly.FullName == typeof(T).Assembly.FullName)
                        {
                            MethodInfo mapMethod = typeof(Program).GetMethod("Map");
                            MethodInfo genericMethod = mapMethod.MakeGenericMethod(property.GetValue(newObj).GetType());
                            var obj2 = genericMethod.Invoke(null, new object[] { property.GetValue(newObj), JsonSerializer.ToString(property.GetValue(newObj)) });
    
                            foreach (var property2 in obj2.GetType().GetProperties())
                            {
                                if (property2.GetValue(obj2) != null)
                                {
                                    property.GetValue(obj).GetType().GetProperty(property2.Name).SetValue(property.GetValue(obj), property2.GetValue(obj2));
                                }
                            }
                        }
                        else
                        {
                            property.SetValue(obj, property.GetValue(newObj));
                        }
                    }
                }
    
                return obj;
            }
        }
    }
