    public static class Extensions {
        public static bool IsNullOrEmpty(this string theString) {
            return string.IsNullOrEmpty(theString);
        }
    }
    // Code elsewhere.
    string test = null;
    Console.WriteLine(test.IsNullOrEmpty()); // Valid code.
    Console.WriteLine(Extensions.IsNullOrEmpty(test)); // Valid code.
