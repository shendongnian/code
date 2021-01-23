    public interface ICommand
    {
        bool Execute();
    }
    
    public static Class Parser
    {
        public ICommand Parse(string commandString) { 
             // Parse your string and create Command object
        }
    }
