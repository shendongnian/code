    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;
        [STAThread]
        static void Main(string[] args)
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //if parameter -window is passed - opens main form, else displays Bad params message
            if(args[0] == "-window")
                Application.Run(new main());
            else
            {
                //Attach console process
                AttachConsole(ATTACH_PARENT_PROCESS);
                Console.WriteLine("Bad params");
            }
        }
    }
