    Action givenAction = null;
    mockDipatcher
      .AssertWasCalled(x => x.Invoke(Arg<Action>.Is.Anything))
      // get the argument passed. There are other solutions to achive the same
      .WhenCalled(call => givenAction = (Action)call.Arguments[0]);
    // evaluate if the given action is a call to the mocked DialogService   
    // by calling it and verify that the mock had been called:
    givenAction.Invoke();
    mockDialogService.AssertWasCalled(x => x.Prompt(message));
