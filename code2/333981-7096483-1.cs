    // Provide some default behavior that will break things
    // if the wrong value comes in.
    Isolate
      .WhenCalled(() => Widget.GetPrice(0))
      .WillThrow(new InvalidOperationException());
    // Now specify the right behavior if the arguments match.
    Isolate
      .WhenCalled(() => Widget.GetPrice(123))
      .WithExactArguments()
      .WillReturn("A");
