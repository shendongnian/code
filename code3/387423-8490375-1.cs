    static void Main()
    {
        LoginForm fLogin = new LoginForm();
        if (fLogin.ShowDialog() == DialogResult.OK)
        {
            Application.Run(new MainForm());
        }
        else
        {
            Application.Exit();
        }
    }
