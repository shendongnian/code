        public class DelegateCommand<T> : ICommand
    {
        private Predicate<T> _canExecuteMethod;
        private readonly Action<T> _executeMethod;
        public event EventHandler CanExecuteChanged;
        public DelegateCommand(Action<T> executeMethod) : this(executeMethod, null)
        {
        }
        public DelegateCommand(Action<T> executeMethod, Predicate<T> canExecuteMethod)
        {
            this._canExecuteMethod = canExecuteMethod;
            this._executeMethod = executeMethod ?? throw new ArgumentNullException(nameof(executeMethod), "Command is not specified."); 
        }
        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
                CanExecuteChanged(this, null);
        }
        public bool CanExecute(object parameter)
        {
            return _canExecuteMethod == null || _canExecuteMethod((T)parameter) == true;
        }
        public void Execute(object parameter)
        {
            _executeMethod((T)parameter);
        }
    }
