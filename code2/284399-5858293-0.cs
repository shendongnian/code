    public static class SessionManager
        {
            private static ISessionFactory _sessionFactory = null;
            private static ISessionFactory SessionFactory
            {
                get
                {
                    if (_sessionFactory == null)
                    {
                        //check whether we're in web context or win context, and create the session factory accordingly.
                        if (System.Web.HttpContext.Current != null)
                        {
                            if (_sessionFactory == null)
                            {
                                _sessionFactory = DAOBase.GetSessionFactory();
                            }
                        }
                        else
                        {
                            _sessionFactory = DAOBase.GetSessionFactoryForWin();
                        }
                    }
                    return _sessionFactory;
                }
            }
    
            public static void BindSessionToRequest()
            {
                ISession session = SessionManager.SessionFactory.OpenSession();
                NHibernate.Context.CurrentSessionContext.Bind(session);
            }
    
            public static bool CurrentSessionExists()
            {
                return NHibernate.Context.CurrentSessionContext.HasBind(SessionFactory);
            }
    
            public static void UnbindSession()
            {
                ISession session = NHibernate.Context.CurrentSessionContext.Unbind(SessionManager.SessionFactory);
                if (session != null && session.IsOpen)
                {
                    session.Close();
                }
            }
    
            public static ISession GetCurrentSession()
            {
                return SessionFactory.GetCurrentSession();
            }
        }
