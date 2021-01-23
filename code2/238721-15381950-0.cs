    public static string ExceptChars(this string str, IEnumerable<char> toExclude)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < str.Length; i++)
                {
                    char c = str[i];
                    if (!toExclude.Contains(c))
                        sb.Append(c);
                }
                return sb.ToString();
            }
    
            public static bool SpaceCaseInsenstiveComparision(this string stringa, string stringb)
            {
                return (stringa==null&&stringb==null)||stringa.ToLower().ExceptChars(new[] { ' ', '\t', '\n', '\r' }).Equals(stringb.ToLower().ExceptChars(new[] { ' ', '\t', '\n', '\r' }));
            }
