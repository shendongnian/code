    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;
            return _canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            if (_execute != null)
                _execute(parameter);
        }
    }
    public partial class MainWindow : Window
    {
        public static RelayCommand ColorCmd = new RelayCommand(xxxx.ColorCmdExecuted, null);
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    public class xxxx
    {
        public static void ColorCmdExecuted(object parameter)
        {
            var target = parameter as Panel;
            if (target != null)
            {
                target.Background = target.Background == Brushes.AliceBlue ? Brushes.LemonChiffon : Brushes.AliceBlue;
            }
        }
    }
