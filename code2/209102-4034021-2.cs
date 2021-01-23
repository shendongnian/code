     public static class ExtensionLib
     {
            
            public static string MyConcat(this string input, params string[] others)
            {
                if (others == null || others.Length == 0)
                   return input;
                string retVal = input;
                foreach(string str in others)
                {
                    if (String.IsNullOrEmpty(str))
                        return input;
                    retVal += str;
                }
                return retVal;
            }
     }
