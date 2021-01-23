    public static bool IsHex(string text)
    {
        return text.All(IsHexChar); 
    }
    private static bool IsHexCharOrNewLine(char c)
    {
        return (c >= '0' && c <= '9') ||
               (c >= 'A' && c <= 'F') ||
               (c >= 'a' && c <= 'f') ||
               c == '\n'; // You may want to test for \r as well
    }
