    public class SessionService : ISessionService
    {
        public SessionService(ISessionFactory factory, ISessionRepository repository)
        {
            Factory = factory;
            Repository = repository;
        }
    
        public ISessionFactory Factory { get; private set; }
        public ISessionRepository Repository { get; private set; }
    
        public ISession StartSession(SessionCriteria criteria)
        {
            var session = Repository.GetSession(criteria);
    
            if (session == null)
                session = Factory.CreateSession(criteria);
            else if (!session.CanResume)
                thrown new InvalidOperationException("Cannot resume the session.");
    
            return session;
        }
    }
