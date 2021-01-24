    public static class DictionaryExtensions
    {
        /// <summary>
        /// Expected to have 2 dictionaries with same keys
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dict1"></param>
        /// <param name="dict2"></param>
        /// <returns></returns>
        public static bool IsEqual<T>(
            this Dictionary<string, T> dict1,
            Dictionary<string, T> dict2)
        {
            foreach (var keyValuePair1 in dict1)
            {
                if (!keyValuePair1.Value.Equals(dict2[keyValuePair1.Key]))
                    return false;
            }
    
            return true;
        }
    }
