    public MainPage()
        {      
            InitializeComponent();
            BindingContext = new ListViewTestModel();;
        }
 
    public ListViewTestModel()
            {
                List<ListItemTestModel> itemList = new List<ListItemTestModel>();
    
                for (int i = 0; i < 40; i++)
                {
                    itemList.Add(new ListItemTestModel { Name = "Test" });
                }
    
                Items = new ObservableCollection<ListItemTestModel>(itemList);
            }
