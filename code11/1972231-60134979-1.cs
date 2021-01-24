        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Audio\audio1.wav");
            player.PlayLooping();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtSample.Text = Guid.NewGuid().ToString();
        }
