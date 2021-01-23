        public static string TrimStart(this string source, string value, StringComparison comparisonType)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            int valueLength = value.Length;
            int startIndex = 0;
            while (source.IndexOf(value, startIndex, comparisonType) == startIndex)
            {
                startIndex += valueLength;
            }
            return source.Substring(startIndex);
        }
        public static string TrimEnd(this string source, string value, StringComparison comparisonType)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            int sourceLength = source.Length;
            int valueLength = value.Length;
            int count = sourceLength;
            while (source.LastIndexOf(value, count, comparisonType) == count - valueLength)
            {
                count -= valueLength;
            }
            return source.Substring(0, count);
        }
