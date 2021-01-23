        public class SessionManager : ISessionManager
    {
		private  readonly ISessionFactory _sessionFactory;
	
		 SessionManager()
        {
            _sessionFactory = CreateSessionFactory();
        }
	
        public void OpenSession()
        {
            ISession session = _sessionFactory.OpenSession();
            session.BeginTransaction();
            CurrentSessionContext.Bind(session);
        }
        public void CloseSession()
        {
            ISession session = CurrentSessionContext.Unbind(_sessionFactory);
            if (session == null) return;
            try
            {
                session.Transaction.Commit();
            }
            catch (Exception)
            {
                session.Transaction.Rollback();
            }
            finally
            {
                session.Close();
                session.Dispose();
            }
        }
	}
