    [Export(typeof(IServiceProviderFactory))]
    [ExportMetaData("foo", "bar")]
    public class FooServiceProviderFactory : IServiceProviderFactory
    {
        public IServiceProvider CreateServiceProvider(Dependency d)
        {
           return new FooServiceProvider(d);
        }
    }
