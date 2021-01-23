    namespace CustomExtensions
    {
        //Extension methods must be defined in a static class
        public static class StringExtension
        {
            // This is the extension method.
            // The first parameter takes the "this" modifier
            // and specifies the type for which the method is defined.
            public static string TrimAndReduce(this string str)
            {
                return ConvertWhitespacesToSingleSpaces(str).Trim();
            }
    
            public static string ConvertWhitespacesToSingleSpaces(this string value)
            {
                return Regex.Replace(value, @"\s+", " ");
            }
        }
    }
