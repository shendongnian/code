    public static bool IsDigit(char c)
    {
       if (!IsLatin1(c))
       {
           return (CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.DecimalDigitNumber);
       }
       return ((c >= '0') && (c <= '9'));
    }
