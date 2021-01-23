    public class DelegateCommand : ICommand
    {
        Action<object> _execute;
        Predicate<object> _canExecute;
        #region Constructors
        public DelegateCommand()
        {
        }
        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {
        }
        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion // Constructors
        public void Delegate(Action<object> execute)
        {
            _execute = execute;
        }
        public void Delegate(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        #region ICommand Members
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? _execute != null : _canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
                _execute(parameter);
        }
        #endregion // ICommand Members
    }
