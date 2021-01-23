    public interface ICommand
    {
        void Execute();
    }
    
    public class RenameCommand : ICommand
    {
        private string newName;
    
        public RenameCommand(string newName)
        {
            this.newName = newName;
        }
    
        void ICommand.Execute()
        {
            item.rename(newName);
        }
    }
