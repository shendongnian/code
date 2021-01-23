    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        LoginForm form = new LoginForm();
        if (form.ShowDialog() == DialogResult.OK)
            Application.Run(new Form1());
    }
