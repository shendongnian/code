    public partial class AddEntryWindow : Form
    {
        // Making authentication possible.
        AuthenticateUser authenticateUser = new AuthenticateUser();
        // Default constructor to initialize the form.
        public AddEntryWindow()
        {
            InitializeComponent();
        }
        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            new AuthenticationWindow(authenticateUser).ShowDialog();
            MessageBox.Show(authenticateUser.UserName + authenticateUser.Password);
        }
    }
    ...
    public partial class AuthenticationWindow : Form
    {
        // Most important log in information needs to be entered
        // for encrypting and decrypting binary file.
        AuthenticateUser authenticateUser;
        public AuthenticationWindow(AuthenticateUser user)
        {
            InitializeComponent();
            authenticateUser = user;
        }
        ...
        private void btnAuthenticate_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == string.Empty || txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Please fill both information first.");
            }
            else
            {
                // Passing the values to object AuthenticateUser.
                authenticateUser.UserName = txtUserName.Text;
                authenticateUser.Password = txtPassword.Text;
                MessageBox.Show(authenticateUser.UserName + authenticateUser.Password);
                Close();
            }
        }
    }
