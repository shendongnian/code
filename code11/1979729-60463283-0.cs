    public static class Extensions
    {
        public static IEnumerable<string> SplitNthParts(this string source, int length)
        {
            return Enumerable
                .Range(0, (source.Length + length - 1) / length)
                .Select(pos => source
                    .Substring(pos * length, Math.Min(length, source.Length - pos * length)));
        }
    }
