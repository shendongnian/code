    Dictionary<string, string> mainDic = new Dictionary<string, string>() { 
        { "Key1", "Value1" }
    };
    Dictionary<string, string> additionalDic = new Dictionary<string, string>() { 
        { "Key2", "Value2" },
        { "Key3", "Value3" }
    };
    mainDic.AddRange(additionalDic);
...
    namespace MyProject.Helper
    {
        public static class StaticFunctions
        {
            public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dic, Dictionary<TKey, TValue> dicToAdd)
            {
                dicToAdd.ToList().ForEach(x => dic[x.Key] = x.Value);
            }
        }
    }
