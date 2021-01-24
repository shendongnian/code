    public class RelayCommand : ICommand
    {
        public Contact selectedContact;
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        
        public event EventHandler CanExecuteChanged;
        
        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }
        
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }
       
        public void Execute(object parameter)
        {
            selectedContact = parameter as Contact;
            _execute();
        }
        
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
  
