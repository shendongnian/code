    public class ServiceFacade : IService
    {
        private readonly IService service;
        // default constructor
        public ServiceFacade()
        {
            this.service = YourContainer.Current.Resolve<IService>();
        }
        void IService.ServiceOperation()
        {
            this.service.ServiceOperation();
        }
    }
