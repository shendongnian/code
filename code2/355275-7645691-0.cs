     protected override void OnCreateMainForm()
     {
         string[] args = Environment.GetCommandLineArgs();
         try {
               MainView mainView = new MainView(args);
               this.MainForm = mainView;
               Application.EnableVisualStyles();
         }...
     }
