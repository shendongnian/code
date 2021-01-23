    public static class EnumerableExtender
        {
            public static string Separated<T>(this IEnumerable<T> l, string separator)
            {
                var sb = new StringBuilder();
                var first = true;
                foreach (var o in l)
                {
                    if (first) first = false; else sb.Append(separator);
                    sb.Append(o.ToString());
                }
                return sb.ToString();
            }
        } 
