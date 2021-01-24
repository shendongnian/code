     public App()
     {
         this.InitializeComponent();
         this.Suspending += OnSuspending;
         this.EnteredBackground += App_EnteredBackground;
     }
    
     private async void App_EnteredBackground(object sender, EnteredBackgroundEventArgs e)
     {
        var messageDialog = new MessageDialog("To run the application smoothly, please maximize the window.");
        
         await messageDialog.ShowAsync();
     }
