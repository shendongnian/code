    public static bool SamePattern(string s1, string s2)
    {
       if (s1.Length == s2.Length)
       {
          char[] chars1 = s1.ToCharArray();
          char[] chars2 = s2.ToCharArray();
          for (int i = 0; i < chars1.Length; i++)
          {
             int c1 = chars1[i];
             int c2 = chars2[i];
             if ((c1 >= 48 && c1 <= 57) != (c2 >= 48 && c2 <= 57))
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
