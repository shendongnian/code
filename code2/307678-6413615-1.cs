    public static class StringExtension
    {
        public static string GetLast(this string s,int tail_length)
        {
           if(tail_length >= s.Length)
              return s;
           return s.SubString(s.Length - tail_length);
        }
    }
