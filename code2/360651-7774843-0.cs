    public abstract class BaseCommand : ICommand
    {
        // needed to connect to WPF's commanding system
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
    public class AddCommand : BaseCommand
    {
        private readonly MyViewModel _vm;
        public AddCommand(MyViewModel vm)
        {
            this._vm = vm;
        }
        public override bool CanExecute(object parameter)
        {
            // delegate back to your view model
            return _vm.CanExecuteAddCommand(parameter);
        }
        public override void Execute(object parameter)
        {
            _vm.ExecuteAddCommand(parameter);
        }
    }
    public class MyViewModel
    {
        public ICommand AddCommand { get; private set; }
        public MyViewModel()
        {
            AddCommand = new AddCommand(this);
        }
        public bool CanExecuteAddCommand(object parameter)
        {
        }
        public void ExecuteAddCommand(object parameter)
        {
        }
    }
