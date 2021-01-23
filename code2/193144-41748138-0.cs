    public static class InvertStringExtension
    {
        public static string Invert(this string s)
        {
            char[] chars = s.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
                chars[i] = chars[i].Invert();
            return new string(chars);
        }
    }
    public static class InvertCharExtension
    {
        public static char Invert(this char c)
        {
            if (!char.IsLetter(c))
                return c;
            
            return char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c);
        }
    }
