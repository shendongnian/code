    public class ItemModule: Autofac.Module
    {
        public string QueriesConnectionString { get; }
        public ItemModule(string queriesConnectionString)
        {
            QueriesConnectionString = queriesConnectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ItemQueries>();  // --> not sure if needed
            builder.Register(c => 
            {
               var factory = c.Resolve<ItemQueries.Factory>();
               return factory.Invoke(QueriesConnectionString);
            })  
            .As<IItemQueries>()
            .InstancePerLifetimeScope();
        }
    }
