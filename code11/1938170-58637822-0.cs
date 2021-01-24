    public partial class MainPage: ContentPage
    {
       DataService ds = new DataService();
       public MainPage()
        {
            InitializeComponent();
            Chart1.Chart = new BarChart { Entries = entries, LabelTextSize = (float)Convert.ToDouble(Device.GetNamedSize(NamedSize.Large, typeof(Label))), BackgroundColor = SKColors.Transparent };
        }
    
       protected override async void OnAppearing()
        {
            base.OnAppearing();
            listview.ItemsSource = await ds.GetBillsAsync();
        }
    }
