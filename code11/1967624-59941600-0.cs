    public partial class MainPage : ContentPage
    {
        public Double height { get; set; }
        public MainPage()
        {
            InitializeComponent();
            height = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
            BindingContext = this;
        }
    }
