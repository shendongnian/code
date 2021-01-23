    [STAThread]
    public static int Main(string[] args)
    {
       if (args.Length > 0)
       {
          // run console code here
       }
       else
       {
          // start up the win form app
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new MainForm());
       }
    
       return 0;
    }
