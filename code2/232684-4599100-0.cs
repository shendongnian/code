    // add this class to your project...
    public static class StringExtensions
    {
        public static bool IsIn(this string target, params string[] testValues)
        {
            return testValues.Contains(target);
        }
    }
