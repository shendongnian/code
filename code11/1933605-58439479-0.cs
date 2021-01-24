    public class MyServiceHostFactory : ServiceHostFactory
    {
        private readonly IDependency dep;
        public MyServiceHostFactory()
        {
            this.dep = new MyClass();
        }
        protected override ServiceHost CreateServiceHost(Type serviceType,
            Uri[] baseAddresses)
        {
            return new MyServiceHost(this.dep, serviceType, baseAddresses);
        }
    }
    public class MyServiceHost : ServiceHost
    {
        public MyServiceHost(IDependency dep, Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            if (dep == null)
            {
                throw new ArgumentNullException("dep");
            }
            foreach (var cd in this.ImplementedContracts.Values)
            {
                cd.Behaviors.Add(new MyInstanceProvider(dep));
            }
        }
    }
    public class MyInstanceProvider : IInstanceProvider, IContractBehavior
    {
        private readonly IDependency dep;
        public MyInstanceProvider(IDependency dep)
        {
            if (dep == null)
            {
                throw new ArgumentNullException("dep");
            }
            this.dep = dep;
        }
        #region IInstanceProvider Members
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return this.GetInstance(instanceContext);
        }
        public object GetInstance(InstanceContext instanceContext)
        {
            return new MyService(this.dep);
        }
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            var disposable = instance as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
        #endregion
        #region IContractBehavior Members
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }
        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.InstanceProvider = this;
        }
        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }
        #endregion
    }
