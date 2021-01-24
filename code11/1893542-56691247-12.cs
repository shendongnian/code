    public class Consumer: IConsumer {
        protected internal IScopedService service;
        protected Consumer(IScopedService service) {
            this.service = service
        }
        private IScopedService ScopedService {
            get {
                return service;
            }
        }
        //...
    }
