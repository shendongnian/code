     IContainer container = new Container(
                c => 
                {
                    c.Scan(s=>
                         {
                             // This autoregisters the IFoo to Foo
                             s.AssembliesFromApplicationBaseDirectory();
                             s.WithDefaultConventions();
                         };
                    // `SessionFactory` needs to be a singleton object
                    c.ForSingletonOf<ISessionFactory>()
                     .Use(NHibernateHelper>.BuildSessionFactory());
                    // Add your own interceptor implementation here
                    c.For<IInterceptor>().Use<EmptyInterceptor>();
                    
                    // I assume that `NHibernateSession` uses the `NHibernateSessionModule`
                    // I use a similar implementation named `TransactionBoundaryModule` 
                    c.For<INHibernateSession>()
                     .HybridHttpOrThreadLocalScoped()
                     .Use<NHibernateSession>();
                    // Gets the current session from the `NHibernateSession`
                    // Ensures one session per request
                    c.For<ISession>().Use(x =>
                        {
                            var instance = x.GetInstance<INHibernateSession>();
                            return instance.CurrentSession;
                        });
                    // Same for `StatelessSession`
                    c.For<IStatelessSession>()
                     .Use(x => x.GetInstance<ISessionFactory>()
                     .OpenStatelessSession());
                };
