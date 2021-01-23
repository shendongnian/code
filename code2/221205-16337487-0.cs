    public static class Extensions
    {
        public static string IntToStringWithLeftPad(this int number, int totalWidth)
        {
            return number.ToString().PadLeft(totalWidth, '0');
        }
    }
