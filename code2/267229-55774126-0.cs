    namespace Extensions
    {
        public static class StringExtensions
        {
            public static bool IsNumeric(this string inputString)
            {
                return decimal.TryParse(inputString, out decimal result);
            }
        }
    }
    
    namespace Business
    {
       
        // add here other namespaces
        using Extensions;
        public static class Tools
        {
            public static bool Check(string inputString)
            {
                return inputString.IsNumeric();
            }
        }
    }
