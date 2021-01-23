    MyWebService.Name service = new MyWebService.Name();
    System.Net.WebProxy proxy = new System.Net.WebProxy("10.1.2.3", 8080); //use your proxy here
    
    proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
    service.Proxy = proxy;
