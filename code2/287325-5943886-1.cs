    var fsm = new PassiveStateMachine<ProcessState, Command>();
    fsm.In(ProcessState.Inactive)
       .On(Command.Exit).Goto(ProcessState.Terminated).Execute(SomeTransitionAction)
       .On(Command.Begin).Goto(ProcessState.Active);
    fsm.In(ProcessState.Active)
       .ExecuteOnEntry(SomeEntryAction)
       .ExecuteOnExit(SomeExitAction)
       .On(Command.End).Goto(ProcessState.Inactive)
       .On(Command.Pause).Goto(ProcessState.Paused);
    fsm.In(ProcessState.Paused)
       .On(Command.End).Goto(ProcessState.Inactive).OnlyIf(SomeGuard)
       .On(Command.Resume).Goto(ProcessState.Active);
    fsm.Initialize(ProcessState.Inactive);
    fsm.Start();
    fsm.Fire(Command.Begin);
