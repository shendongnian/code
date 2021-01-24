    public void GetCredentials()
    {
        var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();
        var csmsTestClient = new HttpClient();
        httpClientFactoryMock.CreateClient("csms").Returns(csmsTestClient)
        var service = new dllClass(httpClientFactoryMock);
        var result = service.GetCredentials().Result;
    }
