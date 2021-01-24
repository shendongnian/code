    class Program
        {
            static void Main(string[] args)
            {
                JsonDeserializer jsonDeserializer = new JsonDeserializer();
                MaxNumber maxNumber = new MaxNumber();
                string json = File.ReadAllText(args[0]);
                jsonDeserializer = JsonConvert.DeserializeObject<JsonDeserializer>(json);
                Console.WriteLine(maxNumber.showResult(jsonDeserializer.numbers));
            }
        }
