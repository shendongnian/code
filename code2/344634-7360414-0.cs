        private object lockObject = new object();
        private static ISessionFactory SessionFactory
        {
            get
            {
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
