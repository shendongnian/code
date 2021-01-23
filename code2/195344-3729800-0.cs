    public static class Foo
    {
        public static string Substring(this string input, int startingIndex)
        {
             return Foo.Substring(input, startingIndex, input.Length - startingIndex);
             // or return input.Substring(startingIndex, input.Length - startingIndex);
        }
    
        public static string Substring(this string input, int startingIndex, int length)
        {
             // implementation 
        }
    }
