    string trimmed = input.IfNotNull(s => s.Trim());
    // ...
    public static class YourExtensions
    {
        public static TResult IfNotNull<TSource, TResult>(
            this TSource source, Func<TSource, TResult> func)
        {
            if (func == null)
                throw new ArgumentNullException("func");
            if (source == null)
                return source;
            return func(source);
        }
    }
