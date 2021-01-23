    var myMock = new Mock<IFoo>();
    bool firstTimeExecuteCalled = true;
    
    myMock.Setup(m => m.Execute())
          .Callback(() =>
           {
                if (firstTimeExecuteCalled)
                {
                    firstTimeExecuteCalled = false;
                    throw new SpecificException();
                }
           });
    
    try
    {
        myMock.Object.Execute();
    }
    catch (SpecificException)
    {
        // Would really want to call Assert.Throws instead of try..catch.
        Console.WriteLine("Got exception");
    }
    
    myMock.Object.Execute();
    Console.WriteLine("OK!");
