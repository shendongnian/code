    namespace Foo
    {
        public static class StringExtensions
        {
            public static bool IsNullOrEmpty(this string input)
            {
                return string.IsNullOrEmpty(input);
            }
        }
    }
