     public class RestrictedServiceHost : DomainServiceHostFactory
     {
        private static List<string> _allowedSchemes;
    
        static RestrictedServiceHost ()
        {
            RestrictedProtocolServiceHost._allowedSchemes = new List<string>();
            RestrictedProtocolServiceHost._allowedSchemes.Add( Uri.UriSchemeHttp );
            RestrictedProtocolServiceHost._allowedSchemes.Add( Uri.UriSchemeHttps );
        }
    
        protected override ServiceHost CreateServiceHost ( Type serviceType, Uri[] baseAddresses )
        {
            baseAddresses = baseAddresses.Where( uri => RestrictedProtocolServiceHost._allowedSchemes.Contains( uri.Scheme ) ).ToArray();
                return base.CreateServiceHost( serviceType, baseAddresses );
        }
     }
