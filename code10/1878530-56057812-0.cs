    public static IDictionary<string, string> GetValues(string line) {
        string[] valuesArray = line.Split(' ').Where(x => x.Contains("=")).ToArray();
        IDictionary<string, string> dictionary = new Dictionary<string, string>();
        foreach (var value in valuesArray) {
            string[] nameValue = value.Split('=');
            dictionary.Add(nameValue[0], nameValue[1]);
        }
        return dictionary;
    }
