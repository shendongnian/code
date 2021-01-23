    string trimmed = input.IfNotNull(s => s.Trim());
    // ...
    public static class YourExtensions
    {
        public static T IfNotNull<T>(this T source, Func<T, T> func)
        {
            if (func == null) throw new ArgumentNullException("func");
            if (source == null)
                return source;
            return func(source);
        }
    }
