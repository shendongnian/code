    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ParentFrame.Navigate(new Page1());
        }
        private void ParentFrame_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            if(btn == null || btn.Tag == null)
            {
                return;
            }
            Page page = (Page)Activator.CreateInstance((Type)btn.Tag);
            ParentFrame.Navigate(page);
        }
    }
