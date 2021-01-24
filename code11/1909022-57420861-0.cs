    class Program
    {
        static void Main(string[] args)
        {
            string json = "{\"name\":\"a Name\", \"parents\":{\"father\":1, \"mother\":0}},,,,Look at me! Stuff at the end!";
            using (var stringReader = new StringReader(json))
            {
                using (var jsonReader = new JsonTextReader(stringReader))
                {
                    var serializer = new JsonSerializer();
                    dynamic value = serializer.Deserialize(jsonReader);
                    Console.WriteLine(value.parents.father); // prints 1
                }
            }
        }
    }
