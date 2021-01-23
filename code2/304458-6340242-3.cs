     public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    public class MainWindowViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Client> _clients;
        private int _index;
        public MainWindowViewModel()
        {
            _clients = GetClients();
            _index = 0;
            SelectedName = _clients[_index].Name;
        }
        protected void OnPropertyChange(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();
            clients.Add(new Client()
            {
                Name = "Name1",
            });
            clients.Add(new Client()
            {
                Name = "Name2",
            });
            return clients;
        }
        private string _selectedName;
        public string SelectedName
        {
            get { return _selectedName; }
            set
            {
                if(_selectedName != value)
                {
                    _selectedName = value;
                    OnPropertyChange("SelectedName");
                }
            }
        }
        private RelayCommand _next;
        public RelayCommand Next
        {
            get
            {
                return _next ?? (_next = new RelayCommand(param => this.SetNextName()));
            }
        }
        private void SetNextName()
        {
            _index = _index == _clients.Count - 1 ? 0 : _index + 1;
            SelectedName = _clients[_index].Name;
        }
        
        private RelayCommand _previous;
        public RelayCommand Previous
        {
            get
            {
                return _previous ?? (_previous = new RelayCommand(param => this.SetPreviousName()));
            }
        }
        private void SetPreviousName()
        {
            _index = _index == 0 ? _clients.Count - 1 : _index - 1;
            SelectedName = _clients[_index].Name;
        }
    }
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canexecute;
        public RelayCommand(Action<object> execute) : this(execute, null){}
        
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentException("execute");
            _execute = execute;
            _canexecute = canExecute;
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        public bool CanExecute(object parameter)
        {
            return _canexecute == null || _canexecute(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value;}
            remove { CommandManager.RequerySuggested -= value;}
        }
    }
