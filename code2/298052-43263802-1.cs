      public static bool ContainsAlphaNumeric(string strToCheck)
            {
                foreach(char c in strToCheck)
                {
                    if (char.IsLetterOrDigit(c))
                    {
                        return true;
                    }
                }
                return false;
            }
