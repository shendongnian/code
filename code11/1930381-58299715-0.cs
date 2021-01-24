        public static string GetFirstOccuredExceptionMessage(Exception ex)
        {
            string message ="";
            if (ex != null)
            {            
                if (ex.InnerException == null)
                {
                    return ex.Message;
                }
                else
                {
                  return  GetFirstOccuredExceptionMessage(ex.InnerException);
                }
       
            }
            return ""; 
        }
