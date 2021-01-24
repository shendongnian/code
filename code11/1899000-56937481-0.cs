    public partial class MainWindow : Window
    {
        private KK _kkPage;
        private AIRFOIL _airfoilPage;
        private OB _obPage;
        public MainWindow()
        {
            InitializeComponent();
            _kkPage = new KK();
            _airfoilPage = new AIRFOIL();
            _obPage = new OB();
        }
        private void BtnClickP1(object sender, RoutedEventArgs e)
        {
            Main.Content = _kkPage;
        }
        private void BtnClickP2(object sender, RoutedEventArgs e)
        {
            Main.Content = _airfoilPage;
        }
        private void BtnClickP3(object sender, RoutedEventArgs e)
        {
            Main.Content = _obPage;
        }
    }
