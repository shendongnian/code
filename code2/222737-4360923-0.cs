        public enum MyDateFormats
        {
            FirstFormat, 
            SecondFormat
        }
        
        public string GetFormattedDate(this DateTime date, MyDateFormats format)
        {
           string result = String.Empty;
           switch(format)  
           {
              case MyDateFormats.FirstFormat:
                 result = date.ToString("dd/MM/yyyy HH:mm:ss.tt");
               break;
             case MyDateFormats.SecondFormat:
                 result = date.ToString("dd/MM/yyyy");
                break;
           }
        
        return result;
    }
