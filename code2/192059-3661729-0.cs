    public abstract class BaseCommand : ICommand
    {
        protected IMyViewModel viewModel;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public BaseCommand(IMyViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
