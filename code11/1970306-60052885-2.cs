    public partial class UserControl1 : UserControl
    {
        public event RoutedEventHandler MyClick;
        public UserControl1()
        {
            InitializeComponent();
        }
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if (MyClick != null)
                    MyClick(this, new RoutedEventArgs());
            }
        }
    }
