    static class Program
    {
        // defines for commandline output
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // redirect console output to parent process;
            // must be before any calls to Console.WriteLine()
            AttachConsole(ATTACH_PARENT_PROCESS);
            if (args.Length > 0)
            {
                Console.WriteLine("Yay! I have just created a commandline tool.");
                // sending the enter key is not really needed, but otherwise the user thinks the app is still running by looking at the commandline. The enter key takes care of displaying the prompt again.
                System.Windows.Forms.SendKeys.SendWait("{ENTER}");
                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new QrCodeSampleApp());
            }
        }
    }
