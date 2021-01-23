    public static class Extension
    {
        public static string ConcatinateString<T>(this IEnumerable<T> collection, Func<T, string> GetValue)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in collection)
            {
                sb.Append(GetValue(item));
            }
            return sb.ToString();
        }
    }
 
