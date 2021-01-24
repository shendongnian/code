    public partial class LoginForm : Form
      {
        public LoginForm()
        {
          InitializeComponent();
        }
    
        private void btnLogin_Click(object sender, EventArgs e)
        {
          string username = tbUsername.Text;
          string password = tbPassword.Text;
      
          // check credentials
          if (username == "user" && password == "pass")
          {
              DashboardForm dashboardForm = new DashboardForm();
              dashboardForm.Show();
          }
          else
          {
              MessageBox.Show("Error: credentials not valid");
          }
        }
      }
