    public class AsyncCommand : ICommand
    {
        private readonly Func<object, Task> execute;
        private bool canExecute = true;
        public event EventHandler CanExecuteChanged;
        public AsyncCommand(Func<object, Task> execute)
        {
            this.execute = execute;
        }
        public bool CanExecute(object parameter)
        {
            return canExecute;
        }
        public async void Execute(object parameter)
        {
            if (canExecute)
            {
                canExecute = false;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                try
                {
                    await execute(parameter);
                }
                finally
                {
                    canExecute = true;
                    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
