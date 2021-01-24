    static void Main(string[] args)
    {
        string json = File.ReadAllTextAsync("sample.json").Result;
        var deserializedJson = JsonConvert.DeserializeObject<IEnumerable<IDictionary<string, string>>>(json);
        foreach(var dictionary in deserializedJson)
        {
            Console.WriteLine(" -- Record --");
            foreach(var keyValuePair in dictionary)
            {
                Console.WriteLine($"{keyValuePair.Key}:{keyValuePair.Value}");
            }
            Console.WriteLine();
        }
    }
