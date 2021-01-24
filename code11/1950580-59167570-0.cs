    public interface IService {
        void Start();
    }
    public class SomeActualService : IService {
        public SomeActualService(ServiceSettings settings) {
            // ...
        }
        public void Start() {
            // ...
        }
    }
