    public abstract class FSMBase<State, Command> 
      where State: Enum       // : Enum wants C# 7.3+
      where Command : Enum {
      public Command Commands;
      public State States;
      public void ProcessCommand(Command _command) {
        ...
      }
    }
