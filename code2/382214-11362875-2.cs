    public static class ExceptionHelper
    {
        public static int LineNumber(this Exception e)
        {
    
            int linenum = 0;
            try
            {
                //linenum = Convert.ToInt32(e.StackTrace.Substring(e.StackTrace.LastIndexOf(":line") + 5));
                //For Localized Visual Studio ... In other languages stack trace  doesn't end with ":Line 12"
                linenum = Convert.ToInt32(e.StackTrace.Substring(e.StackTrace.LastIndexOf(' ')));
            
            }
          
    
            catch
            {
                //Stack trace is not available!
            }
            return linenum;
        }
    }
