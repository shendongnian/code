   static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        //Validation flag
        public static bool ValidLogin = false;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            if (ValidLogin)
            {
                Application.Run(new Form1());
            }
        }
    }
In Login.cs:
       private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "x" && txtPassword.Text == "x")
            {
                Program.ValidLogin = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or Password are incorrect.");
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
