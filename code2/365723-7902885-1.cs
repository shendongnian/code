    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        // context is passed instead of a form
        Application.Run(new AnApplicationContext()); 
    }
    private void OnCurrentFormClosed(object sender, EventArgs e)
    {
        ExitThread();
    }
    private void OnApplicationExit(object sender, EventArgs e)
    {
        /* is there anything to do when all forms are closed
        and the application is going to die?*/
    }
    }
