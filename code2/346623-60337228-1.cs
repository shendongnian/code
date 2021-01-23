    public static class StringEx
    {
        public static string RemoveCharacters(this string s, params char[] unwantedCharacters) 
            => s == null ? null : string.Join(string.Empty, s.Split(unwantedCharacters));
    }
