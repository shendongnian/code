    public class MyObjectThatUsesSession
    {
        HttpSessionStateBase _session;
    
        public MyObjectThatUsesSession(HttpSessionStateBase sesssion)
        {
             _session = session ?? new HttpSessionStateWrapper(HttpContext.Current.Session);
        }
    
        public MyObjectThatUsesSession() : this(null)
        {}
    }
