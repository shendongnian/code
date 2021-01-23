        public partial class LoginForm : Form
    {
        //This constructor should only be called by the Designer.
        public LoginForm()
        {
            InitializeComponent();
        }
        public LoginForm(string title) : this()
        {
            TitleLabel.Text = title;
        }
        public Tuple<string, string> Login()
        {
            if (this.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return new Tuple<string, string>(Username.Text, Password.Text);
            }
            else
            {
                return default(Tuple<string, string>);
            }
        }
        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
