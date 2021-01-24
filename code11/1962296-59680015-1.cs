    public sealed partial class MainPage : Page
    {
        String Test { get; set; } = "John";
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = Test;
        }
    }
