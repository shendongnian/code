    public static class StringExtension
    {
        public static string[] Split(this string source, params int[] sizes)
        {
            var length = sizes.Sum();
            if (length > source.Length) return null;
            var resultSize = sizes.Length;
            if (length < source.Length) resultSize++;
            var result = new string[resultSize];
            var start = 0;
            for (var i = 0; i < resultSize; i++)
            {
                if (i + 1 == resultSize)
                {
                    result[i] = source.Substring(start);
                    break;
                }
                result[i] = source.Substring(start, sizes[i]);
                start += sizes[i];
            }
            return result;
        }
    }
