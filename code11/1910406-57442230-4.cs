    namespace MyCode {
    
        public interface IMyService {
            String ServiceCall(MyArgumentClass argument);
        }
    
        public class MyServiceClass : IMyService {
            public string ServiceCall(MyArgumentClass argument) {
                IDontHaveControlOverThis.ServiceClass service = new IDontHaveControlOverThis.ServiceClass();
                return service.ServiceCall(argument);
            }
        }
    }
