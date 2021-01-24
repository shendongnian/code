    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (NativeMethods.AllocConsole()) //allocconsole, never freeconsole since we constantly want to work with it
            {
                var th = new Thread(CommunicateWithConsole); //create a new thread and pass our endless running method, as to not block the UI Thread
                th.Start();
            }
            //show Form1
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        //our method to check the console and write to it
        private static void CommunicateWithConsole()
        {
            while (true)
            {
                var x = Console.ReadLine(); //stay here till console returns a line, can be changed to Console.ReadKey()
                if (x == "Hello WinForms") //if line says this
                    Console.WriteLine("Hello ConsoleWindow"); //output this to console, waring only outputs to our console without debugger
            }
        }
    }
    public partial class NativeMethods
    {
        /// Return Type: BOOL->int
        [System.Runtime.InteropServices.DllImportAttribute("kernel32.dll", EntryPoint = "AllocConsole")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool AllocConsole();
    }
