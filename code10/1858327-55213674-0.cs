    int floor;
        Random random01 = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void permit1_Click(object sender, RoutedEventArgs e)
        {
             //your code here
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            floor = (int)Math.Round(random01.NextDouble(), 0) + 1;
            Button1.Content = floor;
            permit1.IsEnabled = (floor==2) ? true : false;
            /*
            if (floor == 2)
                permit1.IsEnabled = true;
            else
                permit1.IsEnabled = false;
            */
        }
