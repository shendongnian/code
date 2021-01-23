    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            // This would really be the data returned from the web service
            var sampleData = new WsData
                                 {
                                     Name = "Girilas & Gandhi Nagar",
                                     ID = "842",
                                     City = "Bangalore",
                                     Category = "Shopping Mall",
                                     Others = "AC Types:  central\n AC, Split AC Windows\nACWhirlpool:\nMicrowave Oven ..."
                                 };
            this.DataContext = sampleData;
        }
    }
    public class WsData
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string City { get; set; }
        public string Category { get; set; }
        public string Others { get; set; }
    }
