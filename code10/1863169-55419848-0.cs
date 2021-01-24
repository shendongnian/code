    BasicHttpBinding binding = new BasicHttpBinding();
    EndpointAddress address = new EndpointAddress(Uri);
    binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
    binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;
    binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
    
    binding.MessageEncoding = WSMessageEncoding.Text;
    binding.TextEncoding = Encoding.UTF8;
    binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
    
    _client = new TEST_PortClient(binding, address);
    
    if (_client.ClientCredentials != null)
    {
      _client.ClientCredentials.Windows.ClientCredential = new NetworkCredential("username", "password");
      _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
    
    }
    _client.Open();
    
    string message = string.Empty;
    if (_client.TestConnection(ref message))
    {
      // do something
    }
