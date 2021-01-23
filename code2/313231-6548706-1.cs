    public class MyObjectThatUsesSession
    {
        IStateStorage _storage;
    
        public MyObjectThatUsesSession(IStateStorage storage)
        {
             _storage= storage ?? new SessionStorage();
        }
    
        public MyObjectThatUsesSession() : this(null)
        {}
    
        public void DoSomethingWithSession()
        {
            var something = _storage.Get("MySessionKey");
            Console.WriteLine("Got " + something);
        }
    }
    
    public class SessionStorage : IStateStorage
    {
        //TODO: refactor to inject HttpSessionStateBase rather than using HttpContext.
    
        public string Get(string key)
        {
           return HttpContext.Current.Session(key);
        }
    
        public string Set(string key, string data)
        {
           return HttpContext.Current.Session[key] = data;
        }
    }
