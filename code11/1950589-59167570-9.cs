    public interface IServiceRepository {
        IEnumerable<IService> Get();
    }
    public class ServiceRepository : IServiceRepository {
        private readonly List<IService> services = new List<IService>();
        public ServiceFactory(List<ServiceSettings> serviceSettings) {
            foreach (var settings in serviceSettings) {
                services.Add(new SomeActualService(settings));
            }
        }
        public IEnumerable<IService> Get() {
           return services;
        }
    }
