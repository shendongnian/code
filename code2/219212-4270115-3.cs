    public static class Guard
    {
        public static void AssertHex(string value, string parameterName)
        {
            foreach(char entry in value)
            {
                if (!Char.IsNumber(entry))
                {
                    if (entry != 'a' && entry != 'A' && entry != 'b' && entry != 'B' 
                        && entry != 'c' && entry != 'C' && entry != 'd' && entry != 'D' && entry != 'e' && entry != 'E' && entry != 'f' && entry != 'F')
                    {
                        throw new ArgumentException("Not a valid hexidecimal number", parameterName);
                    }
                }
            }
        }
        public static void AssertNotNullOrEmpty(string value, string parameterName)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(parameterName);
        }
    }
