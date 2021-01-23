    private static void outputDictionaryContentsByDescending(Dictionary<string, int> dictionary)
    {
        foreach (var pair in dictionary.OrderByDescending(key => key.Value).Take(20))
        {
            Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
        }
    }
