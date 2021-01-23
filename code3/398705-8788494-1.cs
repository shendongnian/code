    public class CommandFactory
    {
        private readonly Dictionary<string, ICommand> mCommands = new Dictionary<string,ICommand>(StringComparer.OrdinalIgnoreCase);
    
        public void RegisterCommand<TCommand>(string commandKey) where TCommand : ICommand, new()
        {
            // Instantiate the command
            ICommand command = new TCommand();
    
            // Add to the collection
            mCommands.Add(commandKey, command);
        }
    
        public void ExecuteCommand(string commandKey)
        {
            // See if the command exists
            ICommand command;
            if (!mCommands.TryGetValue(commandKey, out command))
            {
                // TODO: Handle invalid command key
            }
    
            // Execute the command
            command.Execute();
        }
    }
