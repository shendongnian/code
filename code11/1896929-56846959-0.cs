    UseDefaultWebProxy = false,
    ProxyAddress = new Uri(proxyHost)
    Security =
    {
        Mode = BasicHttpSecurityMode.Transport,
        Transport = 
        {
            ClientCredentialType = HttpClientCredentialType.None,
            ProxyCredentialType = HttpProxyCredentialType.Basic
        }
    }
