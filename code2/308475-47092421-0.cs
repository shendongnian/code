    using System.ServiceModel;
    
    namespace PgAuthentication
    {
        public class ServiceClientFactory<TChannel> : ChannelFactory<TChannel> where TChannel : class
        {
            public TChannel Create(string url)
            {
                return CreateChannel(new BasicHttpBinding { Security = { Mode = BasicHttpSecurityMode.None } }, new EndpointAddress(url));
            }
        }
    }
