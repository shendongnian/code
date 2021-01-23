	public Window1()
        {
            InitializeComponent();
            this.DataContext = this;
	    LoadData();
        }
    using viewmodel 
	public Window1()
        {
            InitializeComponent();
            DataContext = new Window1ViewModel();
	    LoadData();
        }
	
	//MyItemsource Property for listbox
 	private ObservableCollection<States> _stateslist;
        public ObservableCollection<States> StatesList
        {
            get { return _stateslist; }
            set
            {
                _stateslist = value;
                RaisePropertyChanged(() => StatesList);
            }
        }
       // Sample Data Loading
 	public void LoadData()
        {
            StatesList = new ObservableCollection<States>();
            StatesList.Add(new States
            {
                StateName = "Kerala"
            });
            StatesList.Add(new States
            {
                StateName = "Karnataka"
            });
            StatesList.Add(new States
            {
                StateName = "Goa"
            });
        }
