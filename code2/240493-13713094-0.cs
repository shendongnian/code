    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login();
        } 
        
        private static bool logOut;
        private static void Login()
        {
            LoginForm login = new LoginForm();
            MainForm main = new MainForm();
            main.FormClosed += new FormClosedEventHandler(main_FormClosed);
            if (login.ShowDialog(main) == DialogResult.OK)
            {
                Application.Run(main);
                if (logOut)
                    Login();
            }
            else
                Application.Exit();
        }
        static void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            logOut= (sender as MainForm).logOut;
        }
    }
        
    public partial class MainForm : Form
    {
        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            //timer1.Stop();
            this.logOut= true;
            this.Close();
        }
    }
