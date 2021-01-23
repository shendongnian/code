    public static bool IsDigit(char c)
    {
       if (char.IsLatin1(c))
       {
          return c >= '0' && c <= '9';
       }
       return CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.DecimalDigitNumber;
    }
