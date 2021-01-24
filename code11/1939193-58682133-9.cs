    class SelectPageCommand : ICommand
    {
      public SelectPageCommand(Action<object> executeDelegate, Predicate<object> canExecuteDelegate)
      {
        this.ExecuteDelegate = executeDelegate;
        this.CanExecuteDelegate = canExecuteDelegate;
      }
    
      private Predicate<object> CanExecuteDelegate { get; }
      private Action<object> ExecuteDelegate { get; }
      #region Implementation of ICommand
    
      public bool CanExecute(object parameter) => this.CanExecuteDelegate?.Invoke(parameter) ?? false;
    
      public void Execute(object parameter) => this.ExecuteDelegate?.Invoke(parameter);
    
      public event EventHandler CanExecuteChanged
      {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
      }
    
      #endregion
    }
