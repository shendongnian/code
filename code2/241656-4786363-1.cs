    public static IList<string> KeysLikeAt(this Dictionary<string, object> dictionary, char letter, int index)
    {
        return dictionary.Where(k => k.Key.Length > index && k.Key[index] == letter)
            .Select(k => k.Key).ToList();
    }
    public static IList<string> KeysNotLikeAt(this Dictionary<string, object> dictionary, char letter, int index)
    {
        return dictionary.Where(k => k.Key.Length > index && k.Key[index] != letter)
            .Select(k => k.Key).ToList();
    }
