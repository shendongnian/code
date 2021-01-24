        //field for width
        double actualWidth;
        public MainWindow()
        {
            //attach an eventhandler
            this.SizeChanged += MainWindow_SizeChanged;
            InitializeComponent();
          }
        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //set the fields value
            actualWidth = e.NewSize.Width;
        }
        private void xx()
        {
            //use the fields value for whatever...
            MessageBox.Show(actualWidth.ToString());
        }
