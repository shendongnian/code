    static class StringExtensions
    {
        public static IEnumerable<String> SplitInMultipleParts(this String s)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            for (var p = 0; p < s.Length; p++)
            {
                for (var i = 0; i < s.Length - p; i++)
                    yield return s.Substring(i, p + 1);
            }
        }
    }
