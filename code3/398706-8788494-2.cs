    public class CommandDetails<T> where T : ICommand, new()
    {
        private ICommand mCommand;
    
        public ICommand GetCommand()
        {
            if (/* Determine if the command has been instantiated */)
            {
                // Instantiate the command
                mCommand = new T();
            }
    
            return mCommand;
        }
    }
    
    public void ExecuteCommand(...)
    {
        // See if the command exists
        CommandDetails details;
        // ...
    
        // Get the command
        // Note: If we haven't got the command yet, this will instantiate it for us.
        ICommand command = details.GetCommand();
    
        // ...
    }
