    public interface ICommand
    {
        bool Execute();
    }
    public class ExitCommand : ICommand
    {
        public bool Execute()
        {
             return true;
        }
    }
    
    public static Class Parser
    {
        public static ICommand Parse(string commandString) { 
             // Parse your string and create Command object
             var commandParts = commandString.Split(' ').ToList();
             var commandName = commandParts[0];
             var args = commandParts.Skip(1).ToList(); // the arguments is after the command
             switch(commandName)
             {
                 // Create command based on CommandName (and maybe arguments)
                 case "exit": return new ExitCommand();
                   .
                   .
                   .
                   .
             }
        }
    }
