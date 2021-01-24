    private static ISessionFactory SessionFactoryDB2
            {
                get
                {
                    if (_sessionFactoryDB2 == null)
                    {
                        _sessionFactoryDB2 = Fluently.Configure()
