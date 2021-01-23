    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        try
        {
            Application.Run(new YourTopLevelForm());
        }
        catch
        {
            //Some last resort handler unware of the context of the actual exception
        }
    }
