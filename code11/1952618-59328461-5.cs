    class JsonModel
    {
        public IDictionary<string, IDictionary<string, string>> Company { get; set; }
        public IDictionary<string, string> Country { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("sample.json");
            var jsonModel = JsonConvert.DeserializeObject<JsonModel>(json);
            
            Console.WriteLine("-- Companies-- ");
            foreach(var companyDictionary in jsonModel.Company)
            {
                foreach(var company in companyDictionary.Value)
                {
                    Console.WriteLine($"{company.Key}:{company.Value}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("-- Countries --");
            foreach (var country in jsonModel.Country)
            {
                Console.WriteLine($"{country.Key}:{country.Value}");
            }
        }
    }
