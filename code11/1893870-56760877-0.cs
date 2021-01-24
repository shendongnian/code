    public static class HttpRequestMessageExtensions
    {
        private const string HttpContext = "MS_HttpContext";
        private const string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";
        /* Method body excluded as irrelevant */
        public static string GetClientIpAddress(this HttpRequestMessage request) { ... }
        /** Added this method for handling the authorization header. **/
        public static Dictionary<string, string> HandleAuthorizationHeader(this HttpRequestMessage request)
        {
            Tenant tenant = new Tenant();
            IEnumerable<string> values;
            request.Headers.TryGetValues("Authorization", out values);
            string tenantConfig = ConfigurationUtility.GetConfigurationValue("tenantConfig");
            if (null != values)
            {
                // perform actions on authorization header.
            }
            else if(!string.IsNullOrEmpty(tenantConfig))
            {
                // retrieve the tenant info based on configuration.
            }
            else
            {
                throw new ArgumentException("Invalid request");
            }
            return tenant;
        }
    }
