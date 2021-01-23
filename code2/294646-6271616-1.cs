    public class LinqToHqlGeneratorsRegistry : DefaultLinqToHqlGeneratorsRegistry
    {
        public LinqToHqlGeneratorsRegistry()
            : base()
        {
            this.Merge(new ConcatHqlGenerator());
        }
    }
    private static ISessionFactory CreateSessionFactory()
    {
        var configuration = new NHib.Cfg.Configuration();
        configuration.Properties.Add(NHibernate.Cfg
                                               .Environment.LinqToHqlGeneratorsRegistry, 
    typeof(LinqToHqlGeneratorsRegistry).AssemblyQualifiedName);
        configuration.Configure();
        return configuration.BuildSessionFactory();
    }
