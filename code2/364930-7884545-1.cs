     public class NHibernateHelper
        {
            private static ISessionFactory _sessionFactory;
    
            private static ISessionFactory SessionFactory
            {
                get
                {
                    if (_sessionFactory == null)
                        InitializeSessionFactory();
                    
                    return _sessionFactory;
                }
            }
    
            private static void InitializeSessionFactory()
            {
                _sessionFactory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008
                                  .ConnectionString(@"Server=localhost\SQLExpress;Database=SomeDB;Trusted_Connection=True;")
                                  .ShowSql()
                    )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>())
                    .BuildSessionFactory();
            }
    
            public static ISession OpenSession()
            {
                return SessionFactory.OpenSession();
            }
        }
