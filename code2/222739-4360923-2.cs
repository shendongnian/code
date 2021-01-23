        public enum MyDateFormats
        {
            FirstFormat, 
            SecondFormat
        }
        
        public static string GetFormattedDate(this DateTime date, MyDateFormats format)
        {
           string result = String.Empty;
           switch(format)  
           {
              case MyDateFormats.FirstFormat:
                 result = date.ToString("dd/MM/yyyy hh:mm:ss.tt");
               break;
             case MyDateFormats.SecondFormat:
                 result = date.ToString("dd/MM/yyyy");
                break;
           }
        
           return result;
        }
