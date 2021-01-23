    [TestMethod]
    public void Test()
    {
        HttpContextBase mockHttpContext= MockRepository.GenerateStub<HttpContextBase>();
        HttpRequestBase mockRequest = MockRepository.GenerateMock<HttpRequestBase>();
        HttpResponseBase mockResponse = MockRepository.GenerateMock<HttpResponseBase>();
        ICookie mockCookie = MockRepository.GenerateMock<ICookie>();
        Controller instanceToTest = new Controller(mockCookie);
    
        mockHttpContext.Stub(x => x.Request).Return(mockRequest);
        mockHttpContext.Stub(x => x.Response).Return(mockResponse);
    
        instanceToTest.ControllerContext = new ControllerContext(mockHttpContext, new RouteData(), instanceToTest);
    
        mockCookie.Expect(x=>x.MethodToExpect("Test",mockRequest,mockResponse);
        instanceToTest.MethodToTest();
        mockCookie.VerifyAllExpectations();
    }
