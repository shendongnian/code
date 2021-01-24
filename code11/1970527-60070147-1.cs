    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Height = (SystemParameters.PrimaryScreenHeight * 0.15);
            this.Width = SystemParameters.PrimaryScreenWidth;
        }
    }
