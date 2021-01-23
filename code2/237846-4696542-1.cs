    /// <summary>
    /// factory builder that uses FluentNHibernate to configure and return a SessionFactory
    /// </summary>
    public class SessionFactoryBuilder : Ninject.Activation.IProvider
    {
        private ISessionFactory _sessionFactory;
        /// <summary>
        /// constructor configures a SessionFactory based on the configuration passed in
        /// </summary>
        /// <param name="configuration"></param>
        public SessionFactoryBuilder()
        {
            /// setup configuration here
            var fluentConfig = Fluently.Configure()
                .Database( MsSqlConfiguration.MsSql2005.ConnectionString( connectionString ) );
            this._sessionFactory = fluentConfig.BuildSessionFactory();
        }
        #region IProvider Members
        public object Create( Ninject.Activation.IContext context )
        {
            return _sessionFactory;
        }
        public Type Type
        {
            get { return typeof( ISessionFactory ); }
        }
        #endregion
    }
