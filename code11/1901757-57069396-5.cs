    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Config config = new Config();
            this.BindingContext = config;
            
            //MyColor can be modified runtime
              config.MyColor = "#00FF00";
        }
    }
