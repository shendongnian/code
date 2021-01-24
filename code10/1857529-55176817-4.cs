    public static StringExtensions
    {
        public static string[] Split(this string source, string value, StringSplitOptions options = StringSplitOptions.None)
        {
            return source?.Split(new[] { value }, options);
        }
    }
    ...
    var result = someString.Split(",");
