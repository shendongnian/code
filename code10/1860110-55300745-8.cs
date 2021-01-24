        public static partial class StringsExtensions
        {        
            public static string ToUpperEveryWord(this string s)
            {
                // Check for empty string.  
                if (string.IsNullOrEmpty(s))
                {
                    return string.Empty;
                }
                return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
            }
        }
