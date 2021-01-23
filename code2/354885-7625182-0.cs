    public class MySessionIDManager : SessionIDManager, ISessionIDManager
    {
        public override string CreateSessionID(HttpContext context)
        { 
            return System.Guid.NewGuid().ToString("N");
        }
    }
       
