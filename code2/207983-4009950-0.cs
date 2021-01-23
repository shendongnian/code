    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("pack://application:,,,/icon.jpg", UriKind.Absolute));
            this.Background = myBrush;
        }
    }
