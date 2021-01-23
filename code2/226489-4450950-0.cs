    public class TestClass
    {
        private ServiceController _serviceController;
        [DataMember]
        public ServiceController MyServiceController
        {
            get { return ServiceController.GetServices()[0]; // <-- this returns your service
        }
    }
