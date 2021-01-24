    public partial class MainPage : ContentPage
    {
        public ObservableCollection<LifeDemandData> LifeDemandList { get; set; }
        public ObservableCollection<LifeDemandData> selectedList;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            
            LifeDemandList = new ObservableCollection<LifeDemandData>()
            {
               new LifeDemandData{ DEMAND = "2019/01" , LATEFEE = "22,000" , PREMIUM = "10.00" , ROWCHECK = false },
               new LifeDemandData{ DEMAND = "2019/02" , LATEFEE = "11,987" , PREMIUM = ".00" , ROWCHECK = false },
               new LifeDemandData{ DEMAND = "2019/03" , LATEFEE = "12,456" , PREMIUM = "6.00" , ROWCHECK = false },
               new LifeDemandData{ DEMAND = "2019/04" , LATEFEE = "78,159" , PREMIUM = "3.00" , ROWCHECK = false },
            };
            listview.ItemsSource = LifeDemandList;
        }
        private void CheckBox_CheckChanged(object sender, EventArgs e)
        {
            selectedList = new ObservableCollection<LifeDemandData>();
            for (int i=0;i< LifeDemandList.Count;i++)
            {
                LifeDemandData item = LifeDemandList[i];
                if(item.ROWCHECK)
                {
                    selectedList.Add(item);
                }
            }
            DisplayAlert("Title", selectedList.Count + " item have been selected", "Cancel");
            // do something you want 
        }
    }
