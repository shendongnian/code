    public class ServiceClientFactory<TChannel> : ClientBase<TChannel> where TChannel : class
    {
        public TChannel Create(string url)
        {
            this.Endpoint.Address = new EndpointAddress(new Uri(url));
            return this.Channel;
        }
    }
