    public static class XMLExtension
    {
        public static string GetValue(this XElement input)
        {
            if (input != null)
                return input.Value;
            return null;
        }
        public static bool XMLContains(this string input, string value)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            return input.Contains(value);
        }
    }
