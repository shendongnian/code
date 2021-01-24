            private int radius = 0;
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void RadioButton_Checked(object sender, RoutedEventArgs e)
            {
                if (MilesButton.IsChecked == true)
                {
                    radius = 3956;
                }
            }
