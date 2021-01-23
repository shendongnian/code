    public static Form BackgroundForm;
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        new Thread(new ThreadStart(Secondary)).Start();
        Application.Run(new MainForm());
    }
    static void Secondary()
    {
        BackgroundForm = new Form();
        // Calling Handle creates the system HWND. You do not have to call Show
        // or something similar on this Form to make the handle available or use
        // Invoke or BeginInvoke.
        var handle = BackgroundForm.Handle;
        // Initialize the DLL here with the handle.
        Application.Run();
        // Unintialize the DLL.
    }
