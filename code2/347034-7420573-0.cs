    class A
    {
        private readonly IServiceContainer _services;
        public A(IServiceContainer services)
        {
            _services = services;
        }
        public void Call() 
        {
             var service = (ISomeService)_services.GetService(typeof(ISomeService));
             service.DoSomething();
        }
        public void ChangeService()
        {
             // set the new service instance as 
             // the ISomeService in the service container
             var newService = new SomeService();
             _services.RemoveService(typeof(ISomeService), true);
             _services.AddService(typeof(ISomeService), newService);             
        }
    }
