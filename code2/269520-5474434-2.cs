        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                Label lbl = new Label();
                lbl.Height = 100d;
                lbl.Width = 100d;
                lbl.MouseLeftButtonUp += rec_MouseLeftButtonUp;
                lbl.Content = "Label number "  + i.ToString();
                lbl.Background = Brushes.White;
                lbl.Foreground = Brushes.Black;
                
                LayoutTest.Children.Add(lbl);
            }
        }
        void rec_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Label obj = sender as Label;
            if (null == obj) return;
            obj.Visibility = Visibility.Collapsed;
        }
