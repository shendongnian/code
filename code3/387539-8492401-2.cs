    namespace RepSalesNetAnalysis
    {
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginForm());
    
            LoginForm fLogin = new LoginForm();
            if (fLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1(fLogin.UserName));
            }
            else
            {
                Application.Exit();
            }
        }
    }
