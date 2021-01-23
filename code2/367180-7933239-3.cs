    public class FooCommand : ICommand {
      public void Execute() {
        // foo away!
      }
    }
    
    ...
    
    public class Processor {
      static Processor() {
        ...
        commands["foo"] = new FooCommand();
        ...
      }
    }
