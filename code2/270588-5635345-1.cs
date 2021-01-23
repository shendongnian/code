    public class SessionFactory : ISessionFactory
    {
        public SessionFactory(ISessionValidator validator)
        {
            Validator = validator;
        }
    
        public ISessionValidator Validator { get; private set; }
    
        public Session CreateSession(SessionCriteria criteria)
        {
            var session = new Session(Validator);
    
            // Map properties
    
            return session;
        }
    }
