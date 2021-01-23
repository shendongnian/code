     public class Repository<T> : IRepository<T>
    {
        readonly IActiveSessionManager _activeSessionManager;
        protected ISession Session
        {
            get { return _activeSessionManager.GetActiveSession(); }
        }
        public Repository(IActiveSessionManager activeSessionManager)
        {
            _activeSessionManager = activeSessionManager;
        }
        public int Add(T entity)
        {
            int newId = (int)Session.Save(entity);
            Session.Flush();
            return newId;
        }
        .
        .
        // add the remaining implementations
    }
