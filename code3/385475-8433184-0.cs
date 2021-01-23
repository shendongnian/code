      ICommand _testCommand;
      public ICommand TestCommand
      {
        get
        {
          _testCommand = new DelegateCommand(
            commandParameter =>
            {
              var testButton = commandParameter as Button;
            },
            (commandParameter) => 
            {
              System.Diagnostics.Debugger.Break(); // Force debugger to break
              return true;
            }
          );
          return _testCommand;
        }
      }
