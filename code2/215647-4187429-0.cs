    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
    
        System.Windows.Window startupWindow = null;
        
        if(useLargeMode)
        {
             startupWindow = new LargeMainWindow();
        }
        else 
        {
            startupWindow = new SmallMainWindow();
        }
        window.Show();
    }
