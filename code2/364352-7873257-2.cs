    using System.Diagnostics;
    static class Program
    {
        // get the current process
        var thisProc = Process.GetCurrentProcess();
        // file name of this process
        var procFileName = new System.IO.FileInfo(thisProc.MainModule.FileName).Name;
        // look for all with the same file name as this one.
        foreach (var proc in Process.GetProcessesByName(
                             procFileName.Substring(0, procFileName.LastIndexOf('.'))))
        {
            // if there is another process with the same file name and a different id
            // it means there is a previous instance of the application running
            if (proc.MainModule.FileName == thisProc.MainModule.FileName &&
                proc.Id != thisProc.Id)
            {
                MessageBox.Show("An instance of this application is already running.");
                return; // stop running this instance
            }
        }
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
