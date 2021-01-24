    public abstract class FSMBase<State, Command> 
      where State   : struct  
      where Command : struct {
      public State CurrentState;
      ...        
      // Instead of compile time error we are going to have runtime one,
      // if either State or Command is not enum
      static FSMBase() {
        if (!typeof(State).IsEnum)
          throw new InvalidCastException("Generic pararameter State must be enum!");
        else if (!typeof(Command).IsEnum)
          throw new InvalidCastException("Generic pararameter Command must be enum!");
      }
    }
    ...
    public class MyFSM : FSMBase<MyStates, MyCommands> {
      public override void InitCommandsAndStatesAndTransitiosnAndInitialState() {
        ...
        CurrentState = MyStates.Off;
        ... 
      }
      ...
    }
