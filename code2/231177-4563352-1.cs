    public static class Extensions
    {
        public static char[] GetApplicationInvalidChars(this char[] input)
        {
            //Your list of invalid characters goes below.
            var invalidChars = new [] { '%', '#', 't' };
            return String.Concat(input, invalidChars).ToCharArray();
        }
    }
