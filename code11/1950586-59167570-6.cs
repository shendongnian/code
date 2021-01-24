    public class SomeServiceHost {
        private readonly List<IService> services = new List<IService>();
        public SomeServiceHost(IServiceFactory factory) {
            services = factory.Get().ToList();
        }
        public ServiceStatus Status { get; private set; } = ServiceStatus.Stopped;
        public void Start() {
            Status = ServiceStatus.Starting;
            foreach (var service in services) {
                service.Start();
            }
            Status = ServiceStatus.Running;
        }
    }
