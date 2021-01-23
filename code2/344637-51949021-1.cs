    private static object lockObject = new object();
    private static ISessionFactory SessionFactory
    {
        get
        {
            if (sessionFactory != null)
            {
                return sessionFactory;
            }
            lock (lockObject)
            {
                if (sessionFactory == null)
                {
                    sessionFactory = Configuration().BuildSessionFactory();
                }
                return sessionFactory;
            }
        }
    }
