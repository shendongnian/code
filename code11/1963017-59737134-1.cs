    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            ClearCommand = new DelegateCommand(Clear);
        }
        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; NotifyPropertyChanged(); }
        }
        public ICommand ClearCommand { get; }
        private void Clear(object parameter)
        {
            Text = string.Empty;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
