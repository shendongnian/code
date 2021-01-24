    [STAThread]
    static void Main()
    {
        Control.CheckForIllegalCrossThreadCalls = true;
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
