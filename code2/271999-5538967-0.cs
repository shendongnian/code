    public class WebSessionHolder
    {
        protected HttpSessionState Session
        {
            get {
               if (HttpContext.Current == null)
                   throw new ApplicationException(); //Oops, not running in a web request.  Do something sensible here...
               return HttpContext.Current.Session;
            }
        }
    
        public int? CurrentUserID
        {
            get { return (int?)Session["CurrentUserID"]; }
            set { Session["CurrentUserID"] = value; }
        }
    }
