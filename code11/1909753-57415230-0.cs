    static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeConsole();
        [STAThread]
        static void Main(string[] args) {
            if (args.Length == 0)
            {
                FreeConsole();
                MessageBox.Show("Application running by double-clicking on exe");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmMain());
            }else
            {
                Console.WriteLine("Application is running from cmd with arguments);
            }
        }
    }
