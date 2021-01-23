    public static class Utils
    {
        public static IEnumerable<KeyValuePair<object, object>> ForLinq(this IDictionaryEnumerator iter)
        {
            using (iter as IDisposable)
            {
                while (iter.MoveNext()) yield return new KeyValuePair<object, object>(iter.Key, iter.Value);
            }
        }
    }
