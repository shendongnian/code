     public class RelayCommand : ICommand
    {
        readonly Action _execute;
        public RelayCommand(Action execute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _execute();
        }
        
    }
