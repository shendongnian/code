        public class CompositeCommand : ICommand {
    
        private List<ICommand> subCommands;
        public CompositeCommand()
        {
            subCommands = new List<ICommand>();
        }
        public bool CanExecute(object parameter)
        {
            foreach (ICommand command in subCommands)
            {
                if (!command.CanExecute(parameter))
                {
                    return false;
                }
            }
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            foreach (ICommand command in subCommands)
            {
                command.Execute(parameter);
            }
        }
        public void AddCommand(ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException("Yadayada, command is null. Don't pass null commands.");
            subCommands.Add(command);
        }
    }
