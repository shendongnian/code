    // Add discovery feature.
    m_Host.AddServiceEndpoint(new Discovery.UdpDiscoveryEndpoint());
    m_Host.Description.Behaviors.Add(new Discovery.ServiceDiscoveryBehavior());
    // Add ordinary service feature
    var binding = new NetTcpBinding();
    binding.Security.Message.ClientCredentialType = MessageCredentialType.None;
    binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.None;
    m_Host.AddServiceEndpoint(
            typeof(IMyServiceContract),
            new NetTcpBinding(SecurityMode.None),
            new UriBuilder { Scheme = Uri.UriSchemeNetTcp, Port = 8732, Host = "10.0.0.5" , Path = "MyServiceContractPath" }.Uri
            );
