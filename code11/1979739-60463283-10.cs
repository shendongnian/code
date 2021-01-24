    public static class Extensions
    {
        public static IEnumerable<string> SplitNthParts(this string source, int partSize)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("String cannot be null or empty.", nameof(source));
            }
            
            if (partSize < 1)
            {
                throw new ArgumentException("Part size has to be greater than zero.", nameof(partSize));
            }
            return Enumerable
                .Range(0, (source.Length + partSize - 1) / partSize)
                .Select(pos => source
                    .Substring(pos * partSize, 
                        Math.Min(partSize, source.Length - pos * partSize)));
        }
    }
