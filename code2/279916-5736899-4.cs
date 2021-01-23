    public interface IServiceTypeProvider
    {
        /// <summary>
        /// Gets the service types.
        /// </summary>
        /// <value>The service types.</value>
        IEnumerable<Type> Types { get; }
    }
    Func<Type, ServiceHost> serviceHostFactory
            foreach (Type serviceType in this.ServiceTypeProvider.Types)
            {
                // I do some magic here to query base contracts because all our service implement a marker interface. But you don't need this. But then you might need to extend the type provider interface.
                IEnumerable<Type> contracts = QueryBaseContracts(serviceType );
                var host = this.CreateHost(serviceType);
                foreach (Type contract in contracts)
                {
                    Binding binding = this.CreateBinding();
                    string address = this.CreateEndpointAddress(contract);
                    this.AddServiceEndpoint(host, contract, binding, address);
                }
                host.Description.Behaviors.Add(new ServiceFacadeBehavior());
                this.OpenHost(host);
                this.serviceHosts.Add(host);
            }
        protected virtual ServiceHost CreateHost(Type serviceType )
        {
            return this.serviceHostFactory(serviceType );
        }
    public class YourWcfModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<Func<Type, ServiceHost>>().ToMethod(
                ctx =>
                (serviceType) =>
                ctx.Kernel.Get<NinjectServiceHost>(new ConstructorArgument("serviceType", serviceType), new ConstructorArgument("baseAddresses", new Uri[] { })));
        }
    }
