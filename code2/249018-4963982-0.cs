    public static class StringExtensions
    {
        public static string MyFormat(this string input)
        {
            return string.Format("some formatting {0} Some other formatting", input);
        }
    }
