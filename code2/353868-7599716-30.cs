    using System;
    using System.Windows.Input;
    namespace MyCompany.MyProject.ViewModel
    {
        public class DelegateCommand : ICommand
        {
            private readonly Action<object> _execute;
            private readonly Func<object, bool> _canExecute;
            public DelegateCommand(Action execute)
                : this(execute, CanAlwaysExecute)
            {
            }
            public DelegateCommand(Action execute, Func<bool> canExecute)
            {
                if (execute == null)
                    throw new ArgumentNullException("execute");
                if (canExecute == null)
                    throw new ArgumentNullException("canExecute");
                _execute = o => execute();
                _canExecute = o => canExecute();
            }
            public bool CanExecute(object parameter)
            {
                return _canExecute(parameter);
            }
            public void Execute(object parameter)
            {
                _execute(parameter);
            }
            public event EventHandler CanExecuteChanged;
            public void RaiseCanExecuteChanged()
            {
                if (CanExecuteChanged != null)
                    CanExecuteChanged(this, new EventArgs());
            }
            private static bool CanAlwaysExecute()
            {
                return true;
            }
        }
    }
