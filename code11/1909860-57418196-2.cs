    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private List<string> _comboItems;
        public List<string> ComboItems
        {
            get { return _comboItems; }
            set
            {
                if (value != _comboItems)
                {
                    _comboItems = value;
                    OnPropertyChanged("ComboItems");
                }
            }
        }
        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != _selectedItem)
                {
                    _selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }
        private bool _extraDetails;
        public bool ExtraDetails
        {
            get { return _extraDetails; }
            set
            {
                if (value != _extraDetails)
                {
                    _extraDetails = value;
                    OnPropertyChanged("ExtraDetails");
                }
            }
        }
        public Storyboard showWin;
        public Storyboard hideWin;
        public MainWindow()
        {
            InitializeComponent();
            PopulateCombo();
            showWin = (Storyboard)Resources["showWin"];
            hideWin = (Storyboard)Resources["hideWin"];
            DataContext = this;
        }
        private void PopulateCombo()
        {
            ComboItems = new List<string>
            {
                "EndUser",
                "AppDeveloper"
            };
            SelectedItem = ComboItems.Last();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedItem == "AppDeveloper")
            {
                ExtraDetails = true;
                BeginStoryboard(showWin);
            }
            else
            {
                ExtraDetails = false;
                BeginStoryboard(hideWin);
            }
        }
    }
