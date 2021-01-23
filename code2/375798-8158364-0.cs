    public static string outputDictionaryContents(Dictionary<string, int> list) {
            var keyValuePairs = list.Select(
                kvp => String.Format("{0}, {1}", kvp.Key, kvp.Value)
            );
            return String.Join("\n", keyValuePairs);
    }
