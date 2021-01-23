    public static class DicExtensions{
    
        public static void ReplaceInAllKeys<TValue>(this IDictionary<string, TValue> oldDictionary, string replaceIt, string withIt)
        {
              // Do all the works with just one line of code:
              return oldDictionary
                     .Select(x=> new KeyValuePair<string, TValue>(x.Key.Replace(replaceIt, withIt), x.Value))
                     .ToDictionary(x=> x.Key,x=> x.Value);
        }
    }
