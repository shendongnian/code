    public static bool SamePattern(string s1, string s2)
    {
       if (s1.Length == s2.Length)
       {
          char[] chars1 = s1.ToCharArray();
          char[] chars2 = s2.ToCharArray();
          for (int i = 0; i < chars1.Length; i++)
          {
             if (!Char.IsDigit(chars1[i]) && chars1[i] != chars2[i])
             {
                return false;
             }
             else if (Char.IsDigit(chars1[i]) != Char.IsDigit(chars2[i]))
             {
                return false;
             }
          }
          return true;
       }
       else
       {
          return false;
       }
    }
