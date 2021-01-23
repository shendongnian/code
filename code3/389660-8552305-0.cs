    public static class StringExtensions
    {
        public static bool IsNullEmptyOrZeros(this string value)
        {
            return !string.IsNullOrEmpty(value) && value != "0000";
        }
    }
