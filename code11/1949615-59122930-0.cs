    public class MyHostBuilder : IHostBuilder
    {
        protected readonly IHostBuilder _inner;
        public MyHostBuilder(IHostBuilder inner)
        {
            _inner = inner;
        }
        public IHost Build()
        {
            DoSomethingCustom();
            return _inner.Build();          //Do something custom then pass through
        }
        public void ConfigureContainer<TContainerBuilder>(Action<HostBuilderContext,TContainerBuilder> action)
        {
            _inner.ConfigureContainer(action);  //Pass through without extending
        }
    }        
