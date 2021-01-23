    public static class StringExtensions
    {
        public static string Replace<T>(this string text, T values)
        {
            var sb = new StringBuilder(text);
            var properties = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToArray();
            var args = properties
                .Select(p => p.GetValue(values, null))
                .ToArray();
            for (var i = 0; i < properties.Length; i++)
            {
                var oldValue = string.Format("{{{0}", properties[i].Name);
                var newValue = string.Format("{{{0}", i);
                sb.Replace(oldValue, newValue);
            }
            var format = sb.ToString();
            return string.Format(format, args);
        }
    }
