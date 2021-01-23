    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ShowModalContent(object sender, RoutedEventArgs e)
        {
            modalPresenter.ShowModalContent();
        }
        private void HideModalContent(object sender, RoutedEventArgs e)
        {
            modalPresenter.HideModalContent();
        }
    }
