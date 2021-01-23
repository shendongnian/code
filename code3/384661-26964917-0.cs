    public static void Increment(this Dictionary<string, int> dictionary, string key)
    {
         int val;
         dictionary.TryGetValue(key, out val);
         if (val != null) 
             dictionary[key] = val + 1;
    }
    Dictionary<string, int> dictionary = new Dictionary<string, int>();
    // fill with some data
    dictionary.Increment("someKey");
