    public class RepositoriesModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            // NHibernate
            Bind<ISessionFactory>().ToProvider<SessionFactoryBuilder>()
                .InSingletonScope();
            Bind<ISession>()
                .ToMethod( CreateSession )
                .InRequestScope();
            // Model Repositories
            Bind( typeof( IRepository<> ) ).To( typeof( NHibernateRepository<> ) ).InScope( HttpOrThread );
            Bind<IGameRepository>().To<GameRepository>();
            Bind<ILogRepository>().To<LogRepository>();
            Bind<IMemberRepository>().To<MemberRepository>();
            Bind<IScopeManager>().To<ScopeManager>();
        }
        private ISession CreateSession( Ninject.Activation.IContext context )
        {
            var session = context.Kernel.Get<ISessionFactory>().OpenSession();
            session.EnableFilter( DigitalLights.Model.FluentLogicalDeleteFilter.FilterName );
            return session;
        }
    }
