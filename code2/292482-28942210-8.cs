    Dictionary<string, string> mainDic = new Dictionary<string, string>() { 
        { "Key1", "Value1" },
        { "Key2", "Value2.1" },
    };
    Dictionary<string, string> addDic = new Dictionary<string, string>() { 
        { "Key2", "Value2.2" },
        { "Key3", "Value3" },
    };
    mainDic.AddRangeOverride(addDic); // Overrides all existing keys
    // or
    mainDic.AddRangeNewOnly(addDic); // Adds new keys only
    // or
    mainDic.AddRange(additionalDic); // Throws an error if the key already exists
    // or
    if (!mainDic.ContainsKeys(additionalDic.Keys)) // Checks if the keys exist
    {
        mainDic.AddRange(additionalDic);
    }
...
    namespace MyProject.Helper
    {
        public static void AddRangeOverride<TKey, TValue>(this Dictionary<TKey, TValue> dic, Dictionary<TKey, TValue> dicToAdd)
        {
            dicToAdd.ForEach(x => dic[x.Key] = x.Value);
        }
        public static void AddRangeNewOnly<TKey, TValue>(this Dictionary<TKey, TValue> dic, Dictionary<TKey, TValue> dicToAdd)
        {
            dicToAdd.ForEach(x => { if (!dic.ContainsKey(x.Key)) dic.Add(x.Key, x.Value); });
        }
        public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dic, Dictionary<TKey, TValue> dicToAdd)
        {
            dicToAdd.ForEach(x => dic.Add(x.Key, x.Value));
        }
        public static bool ContainsKeys<TKey, TValue>(this Dictionary<TKey, TValue> dic, IEnumerable<TKey> keys)
        {
            bool result = false;
            keys.ForEachOrBreak((x) => { result = dic.ContainsKey(x); return result; });
            return result;
        }
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }
        public static void ForEachOrBreak<T>(this IEnumerable<T> source, Func<T, bool> func)
        {
            foreach (var item in source)
            {
                bool result = func(item);
                if (result) break;
            }
        }
    }
