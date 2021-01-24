    public sealed partial class MainPage : Page
    {
        public TextBox Main_TextBox => TextBox_1; //*
        public static MainPage rootPage; //*
        public MainPage()
        {
            this.InitializeComponent();
            if (rootPage != null)
            {
                rootPage = this;
            }
        }
    }
