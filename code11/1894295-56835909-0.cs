    public class SessionSource
    {
        private string _connectionStringProvider;
        public SessionSource(string connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }
        public ISession GetSession()
        {
                var session = GetSessionFactory().OpenSession();
                return session;
        }
        private Configuration AssembleConfiguration(string connectionString)
        {
            return Fluently.Configure()
                    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<MappingCandidate>())
                    .Database(() =>
                    {
                        return FluentNHibernate.Cfg.Db.MsSqlConfiguration
                            .MsSql2012
                            .ConnectionString(connectionString);
                    })
                    .BuildConfiguration();
        }
        private ISessionFactory GetSessionFactory()
        {
            var sessionFactory = AssembleConfiguration(_connectionStringProvider).BuildSessionFactory();
            return sessionFactory;
        }
    }
and then like you used Factory.OpenSession() you can inject sessionSource and use it
 using (var session = _sessionSource.GetSession())
 {
with this you can be sure that you have register all required mappings.
