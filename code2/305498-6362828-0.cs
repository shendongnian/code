        public MainWindow()
        {
            InitializeComponent();
            textBox1.Focus();
            this.PreviewMouseDown += new MouseButtonEventHandler(MainWindow_PreviewMouseDown);
            this.PreviewKeyDown += new KeyEventHandler(MainWindow_PreviewKeyDown);
        }
        void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab) e.Handled = true;
        }
        void MainWindow_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
