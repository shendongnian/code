    public static class StringExtensions
        {
            public static bool IsDigits(this string input)
            {
                return input.All(c => !c.IsDigit());
            }
    
            public static bool IsDigit(this char input)
            {
                return (input < '0' || input > '9');
            }
    
        }
