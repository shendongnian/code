       public static int GetMinFromDictionaryList(List<Dictionary<string, int>> parameter, string key)
        {
            var keyValuePairList = parameter.SelectMany(d => d).Select(x => x.Key);
            if (keyValuePairList.Contains(key))
            {
                return parameter.SelectMany(d => d).Where(x => x.Key == key).ToList().Min(x => x.Value);
            }
         return 0;
        }
