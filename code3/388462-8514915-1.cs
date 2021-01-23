    public class MainForm : Form
    {
        Form loginform;
        public MainForm(Form loginForm)
        {
            this.loginForm = loginForm;
        }
        public void CloseForms()
        {
            loginForm.Close();
            this.Close();
        }
    }
