    var client = MockRepository.GenerateStub<IRestClient>();
    
    var mc = new MyClass(client);
    mc.DoIt();
    
    client.AssertWasCalled(c => c.Request(null), o => o.IgnoreArguments());
    var req = (RestRequest)client.GetArgumentsForCallsMadeOn(c => c.Request(null), o => o.IgnoreArguments())[0][0];
    
    Assert.AreEqual("/DoIt", req.Path);
    Assert.AreEqual(WebMethod.Get, req.Method);
