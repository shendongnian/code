    public static class Extensions
    {
        public static T Get<T>(this Dictionary<string, object> dictionary, string key)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException("dictionary");
            }
    
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
    
            return (T)dictionary[key];
        }
    }
