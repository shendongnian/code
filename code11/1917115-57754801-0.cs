    `public partial class MainForm : Form
    {
       private void btnMain_Click(object sender, EventArgs e)
        {
            LoginForm lfrm = new LoginForm;
            LoginForm.ShowDialog();
        }
       private void SecureMethod(){//do sth};
    }
    public partial class LoginForm : Form
    {
       private void btnok_Click(object sender, EventArgs e)
        {
            SecureMethod(); //is not true
            this.close(); //close loginform
        }
    }` 
