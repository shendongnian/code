    public static class StringExtensions
    {
        public static int TryParse(this string input, int valueIfNotConverted)
        {
            int value;
            if (Int32.TryParse(input, out value))
            {
                return value;
            }
            return valueIfNotConverted;
        }
    }
