    public static class Extensions {
        public static string UpTo(this string s, params char[] stopChars) {
            var stopPos = stopChars.Select(c => s.IndexOf(c)).Where(p => p > -1).MinOrDefault(-1);
            return (stopPos >= 0) ? s.Substring(0, stopPos) : s;
        }    
        public static T MinOrDefault<T>(this IEnumerable<T> src, T defval = default) => src.DefaultIfEmpty(defval).Min();
    }
