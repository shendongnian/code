       mockAutoItLibrary = MockRepository.GenerateStub<IAutoItX3>();
       // make loop throw an exception on second call
       // to exit the infinite loop
       mockAutoItLib
         .Stub(m => m.WinWaitActive(
           Arg<string>.Is.Anything, 
           Arg<string>.Is.Anything, 
           Arg<int>.Is.Anything));
         .Repeat.Once();
       mockAutoItLib
         .Stub(m => m.WinWaitActive(
           Arg<string>.Is.Anything, 
           Arg<string>.Is.Anything, 
           Arg<int>.Is.Anything));
         .Throw(new StopInfiniteLoopException());
    
       subject = new Subject(mockAutoItLibrary)
       try
       {
         subject.Run()
       }
       catch(StopInfiniteLoopException)
       {} // expected exception thrown by mock
    
       mockAutoItLib.AssertWasCalled(m => m.WinWaitActive("Open File", "", 0));
