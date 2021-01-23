        public class SessionData
    {
        private Dictionary<string, object> _someData;
        private SessionData()
        {
            _someData = new Dictionary<string, object>();
        }
        public static Dictionary<string, object> SomeData
        {
            get
            {
                SessionData sessionData = (SessionData)HttpContext.Current.Session["sessionData"];
                if (sessionData == null)
                {
                    sessionData = new SessionData();
                    HttpContext.Current.Session["sessionData"] = sessionData;
                }
                return sessionData._someData;
            }
        }
    }
