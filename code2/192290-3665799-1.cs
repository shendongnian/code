    public static class CharExtensions
        {
            public static int CharToInt(this char c)
            {
                if (c < '0' || c > '9')
                    throw new ArgumentException("The character should be a number", "c");
            
                return c - '0';
            }
        }
