    public static ViewData ViewModel { get; private set; }
    
    private void Application_Launching(object sender, LaunchingEventArgs e)
    {
         // note: you should properly Tombstone this data to prevent unnecessary network access
         ViewModel = new ViewData();
    }
