    public class ServiceFactory : IWebServiceFactory {
        public TWebService Create<TWebService>(string url) {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport) {
                MaxReceivedMessageSize = Int32.MaxValue,
                MaxBufferSize = Int32.MaxValue
            };
            var endpoint = new EndpointAddress(url);
            var channelFactory = new ChannelFactory<TWebService>(binding, endpoint);
            TWebService webService = channelFactory.CreateChannel();
            return webService;
        }
    }
    
