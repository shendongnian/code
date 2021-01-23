    private void Form1_Load(object sender, EventArgs e)
    {
        string[] args = Environment.GetCommandLineArgs();
        foreach(string arg in args)
        {
           if(arg == "consoleargument")
           {
               // Run console
           }
        }
    }
