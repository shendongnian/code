    public static class DictionaryExtensions
    {
        public static void CreateNewOrUpdateExisting(this IDictionary<double, int> map, double key, int value)
        {
            if (map.ContainsKey(key))
            {
                map[key]++;
            }
            else
            {
                map.Add(key, value);
            }
        }
    }
