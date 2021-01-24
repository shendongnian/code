    TestCommand = ReactiveCommand.CreateFromTask<int>(async paramater  =>{
       var result = await DoStuff(parameter); // ConfigureAwait(false) might be helpful in more complex scenarios
    
       return result + 5;
    }
    
    TestCommand.Log(this) // there is some customization available here
       .Subscribe(x => SomeVmProperty = x;); // this always runs on Dispatcher out of the box
    
    TestCommand.ThrownExceptions.Log(this).Subscribe(ex => HandleError(ex));
    
    this.WhenAnyValue(x => x.SearchText) // every time property changes
       .Throttle(TimeSpan.FromMilliseconds(150)) // wait 150 ms after the last change
       .Select(x => SearchText) 
       .InvokeCommand(Search); // we pass SearchText as a parameter to Search command, error handling is done by subscribing to Search.ThrownExceptions. This will also automatically disable all buttons bound to Search command
