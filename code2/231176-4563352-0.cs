    public static class Extensions
    {
        public static string GetApplicationInvalidChars(this string input)
        {
            return String.Concat(input, '&', '#', 't'); //replace with your invalid characters
        }
    }
