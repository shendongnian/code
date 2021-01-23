    public class UserForm : Form
    {
        private ICommandProcessor _commandProcessor;
        
        public UserForm()
        {
            // Poor-man's IoC, try to avoid this by using an IoC container
            _commandProcessor = new CommandProcessor();
        }
    
        private void saveUserButton_Click(object sender, EventArgs e)
        {
            _commandProcessor.Process(new SaveUserCommand(GetUserFromFormFields()));
        }
    }
    
    public class CommandProcessor : ICommandProcessor
    {
        public void Process(object command)
        {
            ICommandHandler[] handlers = FindHandlers(command);
            
            foreach (ICommandHandler handler in handlers)
            {
                handler.Handle(command);
            }
        }
    }
