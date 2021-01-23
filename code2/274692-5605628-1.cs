    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    
    using(var kernel = new Kernel())
    {
        Application.Run(kernel);
    }
