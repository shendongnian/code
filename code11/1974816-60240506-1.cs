    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button newBtn = new Button();
            newBtn.Content = "Test";
            newBtn.Name = "btnTest";
            agrid.Children.Add(newBtn);
            newBtn.MouseUp += NewBtn_MouseUp;
            newBtn.PreviewMouseDown += NewBtn_PreviewMouseDown;
        }
        private void NewBtn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Button btn = sender as Button;
            string theName = btn?.Name ?? "Something was Preview Mouse Downed but I don't know what";
            lb.Items.Add($"Button PREVIEW MouseUp {theName}");
        }
        private void NewBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Button btn = sender as Button;
            string theName = btn?.Name ?? "Something was Mouse Upped but I don't know what";
            lb.Items.Add($"Button MouseUp {theName}");
        }
        private void Window_Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            string theName = btn?.Name ?? "Something was CLICKED in the window but I don't know what";
            lb.Items.Add($"Window Button Click {theName}");
        }
    }
