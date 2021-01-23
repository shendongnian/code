    static class Program
      {
       
        //Extension method for string
        public static DateTime? ToNullableDate(this string text)
        {
          return string.IsNullOrEmpty(text)  ? (DateTime?)null : Convert.ToDateTime(text);
        }
    
        static void Main()
        {
          string s = null;
          DateTime? d = s.ToNullableDate();
         
          s = "1/1/2012";
          d = s.ToNullableDate();
        }  
      }
