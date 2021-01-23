    public class Client<T> : ClientBase<T> where T : class
    {
        public T Service { get { return Channel; } }
            public Client() {
        }
            
        public Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
            
        public Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
            
        public Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
    
        public Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
    }
