        public class DelegateCommand : ICommand
        {
            private readonly Action<object> _ExecuteMethod;
            private readonly Func< object, bool> _CanExecuteMethod;
            #region Constructors
            public DelegateCommand(Action<object>executeMethod, Func<object, bool> canExecuteMethod)
            {
                if (null == executeMethod)
                {
                    throw new ArgumentNullException("executeMethod", "Delegate Command Delegates Cannot Be Null");
                }
                _ExecuteMethod = executeMethod;
                _CanExecuteMethod = canExecuteMethod;
            }
            public DelegateCommand(Action<object>executeMethod) : this(executeMethod, null) { }
            #endregion
     
            #region Methods
            public bool CanExecute(object parameter)
            {
                if (_CanExecuteMethod == null) return true;
                return _CanExecuteMethod(parameter);
            }
        
            public void Execute(object parameter)
            {
                if (_ExecuteMethod == null) return;
                _ExecuteMethod(parameter);
            }
            bool ICommand.CanExecute(object parameter)
            {
                return CanExecute(parameter);
            }
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
            void ICommand.Execute(object parameter)
            {
                Execute(parameter);
            }
            #endregion
        }
