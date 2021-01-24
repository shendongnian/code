    public static class Extensions
    {
        public static IEnumerable<string> SplitNthParts(this string source, int size)
        {
            return Enumerable
                .Range(0, (source.Length + size - 1) / size)
                .Select(pos => source
                    .Substring(pos * size, Math.Min(size, source.Length - pos * size)));
        }
    }
