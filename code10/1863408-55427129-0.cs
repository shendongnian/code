    var mockA = new Mock<IClassA>();
    // auto-mocking hierarchies (a.k.a. recursive mocks)
    mockA.Setup(_ => _.ClassB.ClassC.ClassD.Items[0].Name)
        .Returns("My expected value");
    //...
    subject.MethodToTest(mockA.Object);
