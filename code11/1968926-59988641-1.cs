    public class RelayCommand : ICommand
        {
            public RelayCommand(Action execute, Func<bool> canExecute)
            {
                CommandManager.RequerySuggested += (s, e) => CanExecuteChanged(s, e);
                CanExecuteDelegate = canExecute;
                ExecuteDelegate = execute;
            }
            public RelayCommand(Action execute) : this(execute, () => true) { }
            public event EventHandler CanExecuteChanged = delegate { };
            public Func<bool> CanExecuteDelegate { get; set; }
            public Action ExecuteDelegate { get; set; }
            public bool CanExecute(object parameter) => CanExecuteDelegate();
            public void Execute(object parameter) => ExecuteDelegate();
        }
