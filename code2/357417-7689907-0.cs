    WebProxy proxy = null;
    Uri testUri = new Uri("http://www.example.com/"); // replace with REAL url
    Uri proxyEndpoint = WebRequest.GetSystemWebProxy().GetProxy(testUri);
    if (!testUri.Equals(proxyEndpoint))
        proxy = new WebProxy(proxyEndPoint.ToString());
