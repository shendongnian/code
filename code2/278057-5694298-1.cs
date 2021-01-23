    public class Context : ObjectContext
    {
        public Context()
            :base ("name=ModelContainer")
        {
            Companies = CreateObjectSet<Company>();
            Branches = CreateObjectSet<Branch>();
            ContextOptions.LazyLoadingEnabled = true;
            ContextOptions.ProxyCreationEnabled = true;
        }
        public ObjectSet<Company> Companies { get; private set; }
        public ObjectSet<Branch> Branches { get; private set; }
    }
