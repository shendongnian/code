    using System.Collections;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var objArray = new ArrayList
                {
                    new Car {Id = 1, Color = "blue"},
                    new Driver {Id = 1, Firstname = "John"},
                    new Car {Id = 2, Color = "blue"},
                    new Driver {Id = 2, Firstname = "Jane"}
                };
                var json = JsonConvert.SerializeObject(objArray);
    
                var jArray = JArray.Parse(json);
    
                foreach (var child in jArray.Children())
                {
                    if (child.Children().Any(token => token.Path.Contains("Color")))
                    {
                        // we got a Car
                        var car = ((JObject) child).ToObject<Car>();
                    }
                    else if (child.Children().Any(token => token.Path.Contains("Firstname")))
                    {
                        // we got a Driver
                        var driver = ((JObject) child).ToObject<Driver>();
                    }
                }
            }
        }
    
        public class Car
        {
            public int Id { get; set; }
            public string Color { get; set; }
        }
    
        public class Driver
        {
            public int Id { get; set; }
            public string Firstname { get; set; }
        }
    }
