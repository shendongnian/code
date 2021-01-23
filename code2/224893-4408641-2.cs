    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
    
            public static bool IsFormatValid<T>(this T target, string Format)
                where T : IFormattable
            {
                try
                {
                    target.ToString(Format, null);
                }
                catch
                {
                    return false;
                }  
                return true;
            }
        }
    }
