    public static class IntParseExtension
        {
            public static bool TryParseInt(this string s, out int i)
            {
                i = 0;     
                bool retVal = false;
                int index;
                string sNumber;
                index = s.IndexOf("=");
                if (index > -1)
                {
                    sNumber = s.Substring(index + 1);
                    if (sNumber.Length > 0)
                        retVal = int.TryParse(sNumber, out i);
                }
                return retVal;
            }
        }
