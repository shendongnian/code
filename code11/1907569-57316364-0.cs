    public class MainWindowViewModel : ViewModelBase
    {
        private IStatusBarViewModel _statusBar;
        public IStatusBarViewModel StatusBar => _statusBar;
        public MainWindowViewModel(IStatusBarViewModel statusBar)
        {
            _statusBar = statusBar;
        }
    }
