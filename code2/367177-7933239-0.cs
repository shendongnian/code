    public interface ICommand {
      void Execute();
    }
    
    public class Processor {
      private static Dictionary<string, ICommand> commands;
      static Processor() {
        // create and populate the table
      }
      public void ExecuteCommand(string name) {
        // some validation...
        commands[name].Execute();
      }
    }
