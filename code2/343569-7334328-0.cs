    public static bool IsDigit(char c)
        {
          if (char.IsLatin1(c))
          {
            if ((int) c >= 48)
              return (int) c <= 57;
            else
              return false;
          }
          else
            return CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.DecimalDigitNumber;
        }
