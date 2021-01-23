    [TestMethod]
    public void Test()
    {
        // Arrange(A) - create your objects, mocks and stubs
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
        // Act(A) - do the actual operations on the tested class
        instanceToTest.MethodToTest();
        // Assert (A) - Verify your expectations
        mockCookie.VerifyAllExpectations();
    }
