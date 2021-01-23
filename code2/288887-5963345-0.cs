    IFoo mock = MockRepository.GenerateMock<IFoo>();
    // variable for self-made property behavior
    int currentValue;
    // setting the value: 
    mock
      .Stub(x => CurrentValue = Arg<int>.Is.Anything)
      .WhenCalled(call =>
        { 
          currentValue = (int)call.Arguments[0];
          myStub.Raise(/* ...*/);
        })
    // getting value from the mock
    mock
      .Stub(x => CurrentValue)
      // Return doesn't work, because you need to specify the value at runtime
      // it is still used to make Rhinos validation happy
      .Return(0)
      .WhenCalled(call => call.ReturnValue = currentValue);
