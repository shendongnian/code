    // Helper binding to have transport security with user name token
    BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
    binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
    // Rest of your binding configuration comes here
    // Custom binding to have access to more configuration details of basic binding
    CustomBinding customBinding = new CustomBinding(binding);
    SecurityBindingElement element = customBinding.Elements.Find<SecurityBindingElement>();
    // Remove security timestamp because it is not used by your original binding
    element.IncludeTimestamp = false;
    EndpointAddress address = new EndpointAddress("https://...");
    ProxyWebServiceClient client = new ProxyWebServiceClient(customBinding, address);
    client.ClientCredentials.UserName.UserName = "...";
    client.ClientCredentials.UserName.Password = "...";
