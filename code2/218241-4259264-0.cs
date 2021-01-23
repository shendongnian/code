    //Update Service model   for wcf services         
                ServiceModelSectionGroup secgroup = (ServiceModelSectionGroup)_webConfig.GetSectionGroup("system.serviceModel");
                
                //Add the binding section with the settings that enable HTTPS communications
                secgroup.Bindings.BasicHttpBinding.Bindings.Add(CreateBasicHttpBinding("SecureWebBinding",
                                                                                       BasicHttpSecurityMode.Transport,
                                                                                       HttpClientCredentialType.None));
                
    private BasicHttpBindingElement CreateBasicHttpBinding(string name, BasicHttpSecurityMode mode, HttpClientCredentialType credentialType)
        {
            BasicHttpBindingElement basicHttpBinding = new BasicHttpBindingElement();
            basicHttpBinding.Name = name;
            basicHttpBinding.Security.Mode = BasicHttpSecurityMode.Transport;
            basicHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            return basicHttpBinding;
        }
