    public MainWindow()
            {
                InitializeComponent();
            }
    
            public class Program
            {
                public string Word { get; set; }
    
                public void WhenPressed_1(MainWindow mainWind)
                {
                    mainWind.thisLabel.Content = "Pressed";
                }
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Program test = new Program();
                test.WhenPressed_1(this);
            }
