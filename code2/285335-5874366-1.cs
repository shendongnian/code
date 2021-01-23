    public class Repository
    {
        private ISession session;
        
        public Repository(ISession session)
        {
            this.session = session;
        }
    
        public T Get<T>(int id)
        {
            return session.Get<T>(id);
        }
    }
