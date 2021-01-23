    namespace MyProject.Helpers
    {
        public static class StaticFunctions
        {
            public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dic, Dictionary<TKey, TValue> dicToAdd)
            {
                dicToAdd.ToList().ForEach(x => dic[x.Key] = x.Value);
            }
        }
    }
