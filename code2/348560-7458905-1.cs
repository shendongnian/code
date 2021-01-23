    public class SessionFactory
    {
        protected static ISessionFactory sessionFactory;
        private static ILog log = LogManager.GetLogger(typeof(SessionFactory));
    
        //Several functions omitted for brevity
    
        public static ISession GetCurrentSession()
        {
            if(!CurrentSessionContext.HasBind(GetSessionFactory()))
                CurrentSessionContext.Bind(GetSessionFactory().OpenSession());
    
            return GetSessionFactory().GetCurrentSession();
        }
    
        public static void DisposeCurrentSession()
        {
            ISession currentSession = CurrentSessionContext.Unbind(GetSessionFactory());
    
            currentSession.Close();
            currentSession.Dispose();
        }
    }
