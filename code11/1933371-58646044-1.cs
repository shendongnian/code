    static class Program
    {
        [DllImport("kernel32.dll")]
        public static extern bool SetStdHandle(int stdHandle, IntPtr handle);
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("stdout.dll")]
        extern public static void HelloWorld();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetStdHandle(-10, IntPtr.Zero); // stdin
            SetStdHandle(-11, IntPtr.Zero); // stdou
            SetStdHandle(-12, IntPtr.Zero); // stderr
            AllocConsole();
            /* ... */
        }
     }
