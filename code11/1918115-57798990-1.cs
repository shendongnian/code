    public static void Main(string[] args) {
        //ISmtpClient should be injected into ServiceClass
        //when resolved by the container
        ServiceClass service = _container.GetDependency<ServiceClass>();
        var ep = new EntryPoint(service);
        ep.RunAProcess();
    }
    public class EntryPoint {
        private readonly ServiceClass service;
        //Should actually be dependent on an abstraction and not concretion
        ////But will ignore for the purposes of this example
        public EntryPoint(ServiceClass service) {
            this.service = service;
        }
        public void RunAProcess() {
            
            /* More code here */
            
            service.Send(message);
        }
    }
    //Ideally service class should also have an `IService` abstraction
    //But will ignore for the purposes of this example
    public class ServiceClass {
        private readonly ISmtpClient _smtpClient;
        public ServiceClass(ISmtpClient smtpClient) {
            //ServiceClass uses this dependency
            _smtpClient = smtpClient;
        }
        public void Send(Message message) {
            using (var mail = CreateMailMessage(message)) {
                _smtpClient.Send(mail);
            }
        }
    }
    
