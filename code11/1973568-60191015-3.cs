    public class MyWindowViewModel : INotifyPropertyChanged
    {
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }
        public ICommand LostFocusCommand => new ActionCommand(ExecuteLostFocus);
        private void ExecuteLostFocus()
        {
            Console.WriteLine("LostFocus");
        }
        public ICommand GotFocusCommand => new ActionCommand(ExecuteGotFocus);
        private void ExecuteGotFocus()
        {
            Console.WriteLine("GotFocus");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
