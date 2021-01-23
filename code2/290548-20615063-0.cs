    public static class Extension
    {
        public static string Left(this String input, int length)
        {
            return (input.Length < length) ? input : input.Substring(0, length);
        }
    }
