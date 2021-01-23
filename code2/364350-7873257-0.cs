    static class Program
    {
        static internal bool useGui;
        /// <summary>The main entry point for the application.</summary>
        [STAThread]
        static void Main(string[] args)
        {
            useGui = (from arg in args where arg.ToLower() == "/gui").Any();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
