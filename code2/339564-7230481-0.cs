    public static class DictionaryExtensions
    {
        public static NameValueCollection ToNameValueCollection<tValue>(this IDictionary<string, tValue> dictionary)
        {
            var collection = new NameValueCollection();
            foreach(var pair in dictionary)
                collection.Add(pair.Key, pair.Value.ToString());
            return collection;
        }
    }
