    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SearchButtonPressed { private set; get; }
        public MainViewModel()
        {
            SearchButtonPressed = new Command<SearchBar>(HandleSearchPressed);
        }
        private void HandleSearchPressed(SearchBar searchBar)
        {
            LabelTextPress = searchBar.Text;
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
        
        void SearchButtonPress(object sender, EventArgs e)
        {
            LabelTextPress = ((SearchBar)sender).Text;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
