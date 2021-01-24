    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private List<State> _states;
        public List<State> States
        {
            get { return _states; }
            set
            {
                _states = value;
                OnPropertyChanged("States");
            }
        }
        private State _selectedState;
        public State SelectedState
        {
            get { return _selectedState; }
            set
            {
                _selectedState = value;
                SelectedState.DisplayName = SelectedState.ShortName;
                OnPropertyChanged("SelectedState");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            States = new List<State>
            {
                new State() { FullName = "California", ShortName = "CA" },
                new State() { FullName = "New York", ShortName = "NY" },
                new State() { FullName = "Oregon", ShortName = "OR" }
            };
            DataContext = this;
        }
    }
