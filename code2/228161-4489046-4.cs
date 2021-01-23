     public static string ToLowercaseNamingConvention(this string s, bool toLowercase)
            {
                if (toLowercase)
                {
                    var r = new Regex(@"
                    (?<=[A-Z])(?=[A-Z][a-z]) |
                     (?<=[^A-Z])(?=[A-Z]) |
                     (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);
     
                    return r.Replace(s, "_").ToLower();
                }
                else
                    return s;
            }
