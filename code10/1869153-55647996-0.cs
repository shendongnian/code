        public MainWindow()
        {
            InitializeComponent();           
            this.Closing += MainWindow_Closing;
        }
        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Closing -= MainWindow_Closing;
            this.Close();
        }
