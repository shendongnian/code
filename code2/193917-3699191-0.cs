    public static string AsciiOnly(this string input, bool includeExtendedAscii)
    {
        int upperLimit = includeExtendedAscii ? 255 : 127;
        char[] asciiChars = input.Where(c => (int)c <= upperLimit).ToArray();
        return new string(asciiChars);
    }
