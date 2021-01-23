    static class Program
    {
        [STAThread]
        static void Main()
        {
            var mainForm = new MainForm();
            mainForm.Loaded += (sender, e) => { new LoginDialog().ShowDialog(mainForm); };
            Application.Run(mainForm);
        }
    }
