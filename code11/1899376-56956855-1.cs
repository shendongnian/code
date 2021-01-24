     public MainWindowViewModel CurrentModel = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = CurrentModel;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(CurrentModel.minJpValue);
        }
