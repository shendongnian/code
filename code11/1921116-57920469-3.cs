    using GalaSoft.MvvmLight.Command;
    namespace WpfApp5
    {
        public sealed class MainWindowViewModel : ViewModelBase
        {
            public RelayCommand LockCommand { get; set; }
      
            public MainWindowViewModel()
            {
                LockCommand = new RelayCommand(() => ExecuteLockCommand());
            }
            void ExecuteLockCommand()
            {
                //Some code to be execute when menu item clicked
            }
        }
    }
