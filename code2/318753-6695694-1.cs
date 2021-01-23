    public class userNameEventArgs : EventArgs
    {
        public string userName{get;set;}
    }
    public partial class LoginBox : UserControl
    {
        public event EventHandler<userNameEventArgs> LoggedIn;
        public LoginBox()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            LoggedIn(this, new userNameEventArgs(){userName=textBox1.Text});
        }
    }
