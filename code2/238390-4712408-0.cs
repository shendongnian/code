    public static class StringExtensions
    {
        public static string InvertCases(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            var chars = value.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
                chars[i] = char.IsLower(chars[i]) ? char.ToUpper(chars[i]) : char.ToLower(chars[i]);
            return new string(chars);
        }
    }
