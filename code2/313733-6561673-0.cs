    public class WebHttpClient<T> 
    {
        protected WebHttpBinding Binding { get; private set; }
        public WebHttpClient()
        {
            // set default binding here
        }
        public WebHttpClient(WebHttpBinding binding)
        {
            Binding = binding; 
        }
        public T Get(string uri)
        {
            EndpointAddress _endpoint = new EndpointAddress(uri);
            ChannelFactory<T> _factory = new ChannelFactory<T>(Binding, _endpoint);
            _factory.Endpoint.Behaviors.Add(new WebHttpBehavior());
            return _factory.CreateChannel();
        }
    }
