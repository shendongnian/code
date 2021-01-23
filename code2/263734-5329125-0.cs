    BasicHttpBinding basicHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
    basicHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
    System.ServiceModel.Channels.Binding binding = basicHttpBinding;
    MyServiceSoapClient myService =
        new MyServiceSoapClient(binding, new EndpointAddress(url));
    myService.ClientCredentials.ClientCertificate.Certificate = new X509Certificate2(Certificate);
				
