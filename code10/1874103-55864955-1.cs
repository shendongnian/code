       Program test = new Program();
            public MainWindow()
            {
                InitializeComponent();         
                thisButton.Click += delegate(object sender, RoutedEventArgs e) { test.WhenPressed_1(this); };
            }
    
            public class Program
            {
                public string Word { get; set; }
                public void WhenPressed_1(MainWindow mainWind)
                {
                    mainWind.thisLabel.Content = "Pressed";
                }
            }
