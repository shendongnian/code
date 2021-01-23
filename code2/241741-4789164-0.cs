    public class DomainRegistry : Registry
    {
        public DomainRegistry()
            : base()
        {
            Scan(y =>
            {
                y.AssemblyContainingType<IRepository>();
                y.Assembly(Assembly.GetExecutingAssembly().FullName);
                y.With(new RepositoryTypeScanner());
            });
