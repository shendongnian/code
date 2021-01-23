    public class NHibernateHelper
    {
        public static ISessionFactory CreateSessionFactory()
        {
            var nhConfig = new Configuration();
            nhConfig.Configure();
            return Fluently.Configure(nhConfig)
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<Reservation>()
                    .Conventions.Add(ForeignKey.EndsWith("Id")))
    #if DEBUG
                .ExposeConfiguration(cfg =>
                {
                    new SchemaExport(cfg)
                        .SetOutputFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "schema.sql"))
                        .Create(true, false);
                })
    #endif
                .BuildSessionFactory();
        }
        
        public static ISession GetSession(ISessionFactory sessionFactory)
        {
            ISession session;
            if (CurrentSessionContext.HasBind(sessionFactory))
            {
                session = sessionFactory.GetCurrentSession();
            }
            else
            {
                session = sessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
            }
            return session;
        }
        public static void EndContextSession(ISessionFactory sessionFactory)
        {
            var session = CurrentSessionContext.Unbind(sessionFactory);
            if (session != null && session.IsOpen)
            {
                try
                {
                    if (session.Transaction != null && session.Transaction.IsActive)
                    {
                        // an unhandled exception has occurred and no db commit should be made
                        session.Transaction.Rollback();
                    }
                }
                finally
                {
                    session.Dispose();
                }
            }
        }
    }
