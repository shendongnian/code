    public static class StringExt
    {
        public static bool ContainsNumber(this string str)
        {
            return str.Any(c => Char.IsNumber(c)); 
        }
    }
