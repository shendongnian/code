     public static bool IsDigit(char c)
        {
          if (!char.IsLatin1(c))
            return CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.DecimalDigitNumber;
          if ((int) c >= 48)
            return (int) c <= 57;
          else
            return false;
        }
