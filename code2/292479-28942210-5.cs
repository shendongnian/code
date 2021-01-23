    Dictionary<string, string> mainDic = new Dictionary<string, string>() { 
        { "Key1", "Value1" },
        { "Key2", "Value2.1" },
    };
    Dictionary<string, string> addDic = new Dictionary<string, string>() { 
        { "Key2", "Value2.2" },
        { "Key3", "Value3" },
    };
    mainDic.AddRangeOverride(addDic); // Overrides all existing keys 
    mainDic.AddRangeNewOnly(addDic); // Adds new keys only
    mainDic.AddRange(addDic); // Throws an error if the key already exists
...
    namespace MyProject.Helper
    {
        public static void AddRangeOverride<TKey, TValue>(this Dictionary<TKey, TValue> dic, Dictionary<TKey, TValue> dicToAdd)
        {
            dicToAdd.ToList().ForEach(x => dic[x.Key] = x.Value);
        }
        public static void AddRangeNewOnly<TKey, TValue>(this Dictionary<TKey, TValue> dic, Dictionary<TKey, TValue> dicToAdd)
        {
            dicToAdd.ToList().ForEach(x => { if (!dic.ContainsKey(x.Key)) dic.Add(x.Key, x.Value); });
        }
        public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dic, Dictionary<TKey, TValue> dicToAdd)
        {
            dicToAdd.ToList().ForEach(x => dic.Add(x.Key, x.Value));
        }
    }
