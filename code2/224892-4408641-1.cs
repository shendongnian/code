    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
    
            public static bool IsFormatValid<T>(this T target, string Format)
                where T : IFormattable
            {
                try
                {
                    target.ToString(Format, CultureInfo.CurrentCulture);
                }
                catch
                {
                    return false;
                }  
                return true;
            }
        }
    }
