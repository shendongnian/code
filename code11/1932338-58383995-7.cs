    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SearchButtonPressed { private set; get; }
        public MainViewModel()
        {
            SearchButtonPressed = new Command<string>(HandleSearchPressed);
        }
        private void HandleSearchPressed(string searchText)
        {
            LabelTextPress = searchText;
        }
        string _labelTextPress;
        public string LabelTextPress
        {
            get
            {
                return "You entered after press: " + _labelTextPress;
            }
            set
            {
                if (_labelTextPress != value)
                {
                    _labelTextPress = value;
                    OnPropertyChanged();
                }
            }
        }
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
