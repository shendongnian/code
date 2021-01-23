    internal static bool IsAscii(string value, bool permitCROrLF)
    {
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }
        foreach (char ch in value)
        {
            if (ch > '\x007f')
            {
                return false;
            }
            if (!permitCROrLF && ((ch == '\r') || (ch == '\n')))
            {
                return false;
            }
        }
        return true;
    }
