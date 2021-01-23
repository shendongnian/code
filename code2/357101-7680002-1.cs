    [TestMethod]
    public void Test()
    {
        // The context is a Stub - you just want it to return the mocked request and response
        HttpContextBase mockHttpContext= MockRepository.GenerateStub<HttpContextBase>();
        HttpRequestBase mockRequest = MockRepository.GenerateMock<HttpRequestBase>();
        HttpResponseBase mockResponse = MockRepository.GenerateMock<HttpResponseBase>();
        ICookie mockCookie = MockRepository.GenerateMock<ICookie>();
        Controller instanceToTest = new Controller(mockCookie);
        
        // Stub will return the mocked request and response on every call (similar to SetupResult)
        mockHttpContext.Stub(x => x.Request).Return(mockRequest);
        mockHttpContext.Stub(x => x.Response).Return(mockResponse);
    
        instanceToTest.ControllerContext = new ControllerContext(mockHttpContext, new RouteData(), instanceToTest);
    
        mockCookie.Expect(x=>x.MethodToExpect("Test",mockRequest,mockResponse);
        instanceToTest.MethodToTest();
        mockCookie.VerifyAllExpectations();
    }
