    public enum StateEnum
    {
       NoQuarterState,
       SomeOtherState
    }
    StateEnum GetState { get; }
    if(gumballMachine.GetState.Equals(StateEnum.NoQuarterState)) { ... }
