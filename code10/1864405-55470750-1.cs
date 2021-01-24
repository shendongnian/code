    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Data> MySource { get; set; }
       
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
   
            MySource = new ObservableCollection<Data>()
            {
              new Data() {Content="Entry_1" },
            };
            listView.ItemsSource = MySource;
        }
        
        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("title", MySource[0].Content, "cancel");
        }
    }
