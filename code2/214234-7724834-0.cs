    public class FilteredServiceHostFactory : HttpServiceHostFactory
    {
        private static readonly List<string> _allowedSchemes;
        static FilteredServiceHostFactory()
        {
            _allowedSchemes = new List<string> {Uri.UriSchemeHttp, Uri.UriSchemeHttps};
        }
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            baseAddresses = baseAddresses.Where(uri => _allowedSchemes.Contains(uri.Scheme)).ToArray();
            return base.CreateServiceHost(serviceType, baseAddresses);
        }
    }
