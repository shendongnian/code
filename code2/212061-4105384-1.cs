    public static class DictionaryExcetions
    {
        public static T Get<T>(this Dictionary<string, object> instance, string name)
        {
            return (T)instance[name];
        }
    
    }
    var age = dictionary.Get<int>("age");
