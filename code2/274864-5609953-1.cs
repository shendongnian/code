    [Test]
    public void StubMethodWithStringParameter_ScriptTwoResponses_SameResponseReceived()
    {
        IMessageProvider stub = MockRepository.GenerateStub<IMessageProvider>();
    
        stub.Expect(mp => mp.GetMessageForValue("a"))
            .Return("First call")
            .Repeat.Once();
        stub.Expect(mp => mp.GetMessageForValue("a"))
            .Return("Second call");
        Assert.AreEqual("First call", stub.GetMessageForValue("a"));
        Assert.AreEqual("Second call", stub.GetMessageForValue("a"));
    }
 
