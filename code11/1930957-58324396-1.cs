    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (NativeMethods.AllocConsole()) //allocconsole
            {
                var th = new Thread(CommunicateWithConsole); //create a new thread and pass our endless running method, as to not block the UI Thread
                th.Start();
            }
            //register to ApplicationExit if you want to free the Console when this happens
            Application.ApplicationExit += Application_ApplicationExit;
            //show Form1
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            NativeMethods.FreeConsole();
        }
        //our method to check the console and write to it
        private static void CommunicateWithConsole()
        {
            try
            {
                while (true)
                {
                    var x = Console.ReadLine(); //stay here till console returns a line, can be changed to Console.ReadKey()
                    if (x == "Hello WinForms") //if line says this
                        Console.WriteLine("Hello ConsoleWindow"); //output this to console, waring only outputs to your console if application is not run with a debugger
                }
            }
            catch (IOException e)
            {
                //when we close our app and call freeconsole an IOException can occurr, handle that case
            }
        }
    }
    public partial class NativeMethods
    {
        [System.Runtime.InteropServices.DllImportAttribute("kernel32.dll", EntryPoint = "AllocConsole")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool AllocConsole();
        [System.Runtime.InteropServices.DllImportAttribute("kernel32.dll", EntryPoint = "FreeConsole")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool FreeConsole();
    }
