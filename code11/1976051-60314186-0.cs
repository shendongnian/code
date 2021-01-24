    [TestMethod]
    public void Test()
    {
    var classToTest = new ClassToTest();
    
    var methodCalls1 = new List<string>();
    var invocationAction1 = new InvocationAction((ia) =>
    {
         string methodCall = $"{ia.Method.Name} was called with parameters {string.Join(", ", ia.Arguments.Select(x => x?.ToString() ?? "null"))}";
         methodCalls1.Add(methodCall);
    });
    Mock<IMyInterface> mock1 = new Mock<IMyInterface>();
    mock1.Setup(x => x.Method1(It.IsAny<int>())).Callback(invocationAction1);
    mock1.Setup(x => x.Method2(It.IsAny<string>())).Callback(invocationAction1);
    
    // Same for mock2 ...
    
    
    classToTest.MethodToTest(mock1.Object);
    classToTest.DifferentMethodToTest(mock2.Object);
    
    CollectionAssert.AreEqual(methodCalls1, methodCalls2);
    }
