    public Window1()
    {
      InitializeComponent();
      string[] param = Environment.GetCommandLineArgs();
    
      // Your parameter is in the second one since the first contains the executable path or something like that
      string xmlPath = param[1];
    
      // Open and edit your xmlPath 
      // ....
    }
