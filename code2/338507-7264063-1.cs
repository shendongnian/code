    public class ThreadSessionStorage : ISessionStorage
    {
        [ThreadStatic]
        private static ISession _session;
        public ISession Session
        {
            get
            {
                return _session;
            }
            set
            {
                _session = value;
            }
        }
        public ISession GetSessionForKey(string factoryKey)
        {
            return Session;
        }
        public void SetSessionForKey(string factoryKey, ISession session)
        {
            Session = session;
        }
        public IEnumerable<ISession> GetAllSessions()
        {
            return new List<ISession>() { Session };
        }
    }
