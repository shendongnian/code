    System.Threading.Thread.CurrentThread.CurrentUICulture = new 
    System.Globalization.CultureInfo(lang); //my selected lang from menu
    
    ReloadControlString();
    
    //...
    
    private void ReloadControlString()
    {
        System.Resources.ResourceManager resources = new 
        System.Resources.ResourceManager(typeof(FormMain));
    
        this.menuApp.Text = resources.GetString("menuApp.Text");
    }
