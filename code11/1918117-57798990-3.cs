    public static void Main(string[] args) {
        //ISmtpClient should be injected into ServiceClass
        //when resolved by the container or factoty
        IService service = _container.GetDependency<IService>();
        var ep = new EntryPoint(service);
        ep.RunAProcess();
    }
    public class EntryPoint {
        private readonly IService service;
        public EntryPoint(IService service) {
            this.service = service;
        }
        public void RunAProcess() {
            
            /* More code here */
            
            service.Send(message);
        }
    }
    public class ServiceClass : IService {
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
    
