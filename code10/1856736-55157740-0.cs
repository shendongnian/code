    private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
            {
                if ((endpointConfiguration == EndpointConfiguration.WebService1Soap))
                {
                    System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                    result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                    result.Security.Transport.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.Windows;
                    result.MaxBufferSize = int.MaxValue;
                    result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                    result.MaxReceivedMessageSize = int.MaxValue;
                    result.AllowCookies = true;
                    return result;
                }
