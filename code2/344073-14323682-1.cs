      static class Program
    {
        public static SystemParams.clsConnectionClass conn;
        [STAThread]
        static void Main()
        {
                conn = new SystemParams.clsConnectionClass();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Shared.frmMain());           
        }
    }
