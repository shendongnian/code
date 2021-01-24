    HasSomeStaticCall obj = Mock.Create<HasSomeStaticCall>(Behavior.CallOriginal);
    Mock.NonPublic.Arrange<string>(obj, "callStaticThingProtected").Returns("SomeValue");
    var actual = obj.MethodThatCallsTheProtectedcallStaticThing();
    Assert.AreEqual("SomeValue", actual);
    
