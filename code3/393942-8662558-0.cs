    [TestMethod]
    public void TestExecuteAction()
    {
        var response = MockRepository.GenerateStub<HttpResponseBase>();
        response.Output = new StringWriter();
        var httpContext = MockRepository.GenerateMock<HttpContextBase>();
        httpContext.Expect(m => m.Response).Return(response);
        var routeData = new RouteData();
        routeData.Values.Add("action", "FakeAction");
        var context = new ControllerContext(httpContext, routeData, MockRepository.GenerateMock<ControllerBase>());
        var viewResult = new JavaScriptViewResult();
        viewResult.View = MockRepository.GenerateMock<IView>();
        viewResult.ExecuteResult(context);
        Assert.AreEqual("text/javascript", context.HttpContext.Response.ContentType);
    }
