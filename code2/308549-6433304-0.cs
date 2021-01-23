        public partial class LoginForm : Form
        {
            private string somedata = "somedata";
    
            public LoginForm()
            {
                InitializeComponent();
    
                OpenForm(somedata);
            }    
        }
    
        private void OpenForm(string Data)
        {
            SomeForm sf = new SomeForm(Data);
            sf.Show();
        }
