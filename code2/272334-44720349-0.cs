    class LoginForm : Form
    {
        bool UserSuccessfullyAuthenticated { get; private set; }
        void LoginButton_Click(object s, EventArgs e)
        {
            if(AuthenticateUser(/* ... */))
            {
                UserSuccessfullyAuthenticated = true;
                Close();
            }
        }
    }
    static class Program
    {
        [STAThread]
        static void Main()
        {
            LoginForm loginForm = new LoginForm();
            Application.Run(loginForm);
            if(loginForm.UserSuccessfullyAuthenticated)
            {
                // MainForm is defined elsewhere
                Application.Run(new MainForm());
            }
        }
    }
