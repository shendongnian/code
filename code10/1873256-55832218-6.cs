    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Option> _choicesList;
        private Option _selectedChoiceList;
        public Option SelectedChoiceList
        {
            get { return _selectedChoiceList; }
            set { _selectedChoiceList = value; NotifyPropertyChanged(); }
        }
        public ObservableCollection<Option> ChoicesList
        {
            get { return _choicesList; }
            set { _choicesList = value; NotifyPropertyChanged(); }
        }
        public MainWindow()
        {
            InitializeComponent();
            ChoicesList = new ObservableCollection<Option>
            {
                new Option("Contract", new ObservableCollection<object>
                {
                    new Contract(), new Contract(), new Contract()
                }),
                new Option("Service", new ObservableCollection<object>
                {
                    new Service(), new Service(), new Service()
                }),
                new Option("Section", new ObservableCollection<object>
                {
                    new Section(), new Section(), new Section()
                }),
            };
            DataContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
