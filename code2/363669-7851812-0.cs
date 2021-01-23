    namespace System.Windows.Navigation
    {
        public static class NavigationExtensions
        {
            public static int? TryGetKey(this NavigationContext source, string key)
            {
                if (source.QueryString.ContainsKey(key))
                {
                    string value = source.QueryString[key];
    
                    int result = 0;
                    if (int.TryParse(value, out result))
                    {
                        return result;
                    }
                }
    
                return null;
            }
    
            public static string TryGetStringKey(this NavigationContext source, string key)
            {
                if (source.QueryString.ContainsKey(key))
                {
                    return source.QueryString[key];
                }
    
                return null;
            }
        }
    }
