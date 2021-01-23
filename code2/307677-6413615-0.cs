    public static class StringExtension
    {
        public static string GetLast(this string s,int index)
        {
           if(index >= s.Length)
              return s;
           return s.SubString(s.Length - index);
        }
    }
