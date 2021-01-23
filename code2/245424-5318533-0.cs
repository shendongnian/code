    private static SecurityToken GetSamlToken(string realm, string stsEndpoint, ClientCredentials clientCredentials)
        {
            using (var factory = new WSTrustChannelFactory(
                new UserNameWSTrustBinding(SecurityMode.TransportWithMessageCredential), 
                new EndpointAddress(new Uri(stsEndpoint))))
            {
                factory.Credentials.UserName.UserName = clientCredentials.UserName.UserName;
                factory.Credentials.UserName.Password = clientCredentials.UserName.Password;
                factory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
                factory.TrustVersion = TrustVersion.WSTrust13;
                WSTrustChannel channel = null;
                try
                {
                    var rst = new RequestSecurityToken
                                  {
                                      RequestType = WSTrust13Constants.RequestTypes.Issue, 
                                      AppliesTo = new EndpointAddress(realm), 
                                      KeyType = KeyTypes.Bearer, 
                                  };
                    channel = (WSTrustChannel)factory.CreateChannel();
                    return channel.Issue(rst);
                }
                finally
                {
                    if (channel != null)
                    {
                        channel.Abort();
                    }
                    factory.Abort();
                }
            }
