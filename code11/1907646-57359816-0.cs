services.AddSingleton<ISessionSource, SessionSource>();
and class SessionSource
    public class SessionSource : ISessionSource
    {
        private static readonly object _lockObject = new object();
        private static Dictionary<string, ISessionFactory> _sessionFactories = new Dictionary<string, ISessionFactory>();
        public SessionSource()
        {}
        public ISession GetSession(int csName)
        {
            lock (_lockObject)
            {
                var session = GetSessionFactory(csName).OpenSession();
                return session;
            }
        }
        private FluentConfiguration BaseConfiguration()
        {
            return Fluently.Configure()
                    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<MappingCandidate>())
                    .ExposeConfiguration(cfg =>
                    {
                        new SchemaExport(cfg)
                            .Execute(false, false, false);
                    });
        }
        private Configuration AssembleConfiguration(string connectionString)
        {
            return BaseConfiguration()
                    .Database(() =>
                    {
                        return FluentNHibernate.Cfg.Db.MsSqlConfiguration
                            .MsSql2012
                            .ConnectionString(connectionString);
                    })
                    .BuildConfiguration();
        }
        private ISessionFactory GetSessionFactory(int csName)
        {
            var connectionString = Configuration.GetConnectionString(csName);
            if (_sessionFactories.ContainsKey(connectionString))
            {
                return _sessionFactories[connectionString];
            }
            var sessionFactory = AssembleConfiguration(connectionString).BuildSessionFactory();
            _sessionFactories.Add(connectionString, sessionFactory);
            return sessionFactory;
        }
    }
and in e.g controller
using (var session = _sessionSource.GetSession(connectionStringName))
