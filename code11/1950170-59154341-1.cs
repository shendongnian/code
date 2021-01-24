        public partial class MainWindow : Window
        {
            private static string toggle = "blue";//State of button's color
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void button_Click(object sender, RoutedEventArgs e)
            {
                //Switch to decide and toggle the required color
                switch (toggle)
                {
                    case "blue":
                        button.Background = Brushes.Blue;
                        toggle = "red";
                        break;
                    case "red":
                        button.Background = Brushes.Red;
                        toggle = "blue";
                        break;
                }
                
            }
        }
