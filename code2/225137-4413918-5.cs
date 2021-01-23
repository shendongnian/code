    public static class Extensions
    {
        public static string SetWidth(this string item, int width, char padder, bool right = true)
        {
            if (item == null)
                return new string(padder, width);
            if (width > item.Length)
                return right ? item.PadRight(width, padder) : item.PadLeft(width, padder);
            return item.Substring(0, width);
        }
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
    }
