    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    
    
    public class Program
    {
        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
    
            [JsonConverter(typeof(CustomDecimalConverter))]
            public decimal? Salary { get; set; }
        }
        public static void Main()
        {
            // Serializaion  
            var empObj = new Employee { ID = 1, Name = "Manas", Salary = 10000 };
    
            // Convert Employee object to JOSN string format   
            var jsonData = JsonConvert.SerializeObject(empObj);
    
            Console.WriteLine(jsonData);
            Console.ReadLine();
        }
        public class CustomDecimalConverter : JsonConverter
    
        {
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    
            {
    
                writer.WriteValue(((decimal)value).ToString(CultureInfo.InvariantCulture));
    
            }
    
            public override bool CanRead => false;
    
            public override bool CanConvert(Type objectType)
    
            {
    
                return objectType == typeof(decimal) || objectType == typeof(decimal?);
    
            }
    
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    
            {
    
                throw new NotImplementedException();
    
            }
    
    
        }
    }
