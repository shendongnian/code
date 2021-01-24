    public static class StringUtility
    {
        public static string Reverse(this string input)
        {
            char[] arr = input.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
