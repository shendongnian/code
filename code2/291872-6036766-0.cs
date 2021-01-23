    public class UrlManagementProxy : UrlManagementServiceClient, IUrlManagementProxy
    {
        public UrlManagementProxy(Binding binding, EndpointAddress remoteAddress)
            : base(binding, remoteAddress)
        {
        }
    }
