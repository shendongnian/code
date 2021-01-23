    public static class AwesomeExtensions
    {
        public static bool IsPositive(this int number)
        {
            return number > 0;
        }
        public static bool IsNegative(this int number)
        {
            return number < 0;
        }
        
        public static bool IsZero(this int number)
        {
            return number == 0;
        }
        public static bool IsAwesome(this int number)
        {
            return IsNegative(number) && IsPositive(number) && IsZero(number);
        }
    }
