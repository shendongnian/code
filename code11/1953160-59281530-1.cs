    public abstract class FSMBase<State, Command> 
      where State: Enum       // : Enum wants C# 7.3+
      where Command : Enum {
      //TODO: I suggest have these fields private, or at least, protected
      public Dictionary<Transition, State> AvailableTransitions;
      public State CurrentState;
      public void ProcessCommand(Command _command) {
        ...
      }
    }
