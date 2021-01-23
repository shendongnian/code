    static class Program
    {
        internal static Form1 MainForm { get; set; } 
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new Form1();
            Application.Run(MainForm);
        }
    }
    class OtherClass
    {
        public void AddNewTab(TabPage newTabPage)
        {
            Program.MainForm.logFileCollectorTabControl.TabPages.Add(newTabPage);
        }
    }
