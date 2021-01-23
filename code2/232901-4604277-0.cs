    // arrange
    var mock = MockRepository.GenerateMock<IMyInterface>
    mock.Expect(i => i.FunctionThatReturnSomething(param1, param2)).Return("hello");
    mock.Expect(i => i.FunctionThatReturnVoid(param3, param4));
    // set up other stuff for your code (like whatever code depends on IMyInterface)
    var foo = new Foo(mock);
    // act
    foo.DoSomething();
    // assert
    mock.VerifyAll();
