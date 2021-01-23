    namespace Common.Infrastructure.WCF
    {
        public class NHibernateWcfSessionContext : ICurrentSessionContext
        {
            private readonly ISessionFactoryImplementor factory;
    
            public NHibernateWcfSessionContext(ISessionFactoryImplementor factory)
            {
                this.factory = factory;
            }
    
            /// <summary>
            /// Retrieve the current session for the session factory.
            /// </summary>
            /// <returns></returns>
            public ISession CurrentSession()
            {
                Lazy<ISession> initializer;
                var currentSessionFactoryMap = OperationContext.Current.InstanceContext.Extensions.Find<NHibernateContextManager>().SessionFactoryMaps;
                if (currentSessionFactoryMap == null ||
                    !currentSessionFactoryMap.TryGetValue(factory, out initializer))
                {
                    return null;
                }
                return initializer.Value;
            }
    
            /// <summary>
            /// Bind a new sessionInitializer to the context of the sessionFactory.
            /// </summary>
            /// <param name="sessionInitializer"></param>
            /// <param name="sessionFactory"></param>
            public static void Bind(Lazy<ISession> sessionInitializer, ISessionFactory sessionFactory)
            {
                var map = OperationContext.Current.InstanceContext.Extensions.Find<NHibernateContextManager>().SessionFactoryMaps;;
                map[sessionFactory] = sessionInitializer;
            }
    
            /// <summary>
            /// Unbind the current session of the session factory.
            /// </summary>
            /// <param name="sessionFactory"></param>
            /// <returns></returns>
            public static ISession UnBind(ISessionFactory sessionFactory)
            {
                var map = OperationContext.Current.InstanceContext.Extensions.Find<NHibernateContextManager>().SessionFactoryMaps;
                var sessionInitializer = map[sessionFactory];
                map[sessionFactory] = null;
                if (sessionInitializer == null || !sessionInitializer.IsValueCreated) return null;
                return sessionInitializer.Value;
            }
        }
    }
