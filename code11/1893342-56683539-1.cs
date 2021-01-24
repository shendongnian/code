    public class ViewModel
    {
        private bool CanEx { get; set; }
        public DelegateCommand XCommand => new DelegateCommand(X, Can);
        public DelegateCommand YCommand { get; set; }
        public DelegateCommand SwitchCommand { get; set; }
        public ViewModel()
        {
            CanEx = true;
            YCommand = new DelegateCommand(Y, Can);
            SwitchCommand = new DelegateCommand(Switch);
        }
        private void X(object obj) => System.Diagnostics.Debug.WriteLine("X");
        private void Y(object obj) => System.Diagnostics.Debug.WriteLine("Y");
        private bool Can(object obj) => CanEx;
        private void Switch(object obj)
        {
            CanEx = !CanEx;
            XCommand.RaiseCanExecuteChanged();
            YCommand.RaiseCanExecuteChanged();
        }
    }
