    internal class Program
    {
        private static void Main(string[] args)
        {
            string path = @"pathToJsonr.json";
            var d = new DeserializeClass<List<Person>>().Deserialize<List<Person>>(path);
            System.Console.WriteLine(d[0].Name);
        }
    }
    internal class DeserializeClass<T>
    {
        internal T Deserialize<T>(string filename)
        {
            using (var sr = new StreamReader(filename))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(jsonReader);
                }
            }
        }
    }
    internal class Person
    {
        public string CarPlateNumber { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
    [
    
      {
        "CarPlateNumber": "A823BX750",
        "Id": 2,
        "Name": "Peter Peterson",
        "Password": "qwasdty",
        "Phone": "+79162314312"
      }
    ]
