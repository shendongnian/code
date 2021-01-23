    public static class StringExtensions
    {
        public string Join(this IEnumerable<string> source, string sep)
        {
            return string.Join(sep, source.ToArray()); // You can erase `.ToArray()` if you're using .Net 4
        }
    }
