    public class AboutWindow
    {
    
        public static bool IsOpen {get;private set;}
    
        onLoadEvent(....) 
        {
            IsOpen = true;
        }
    
        onUnloadEvent(...) 
        {
            IsOpen = false;
        }
    
    }
    
    
    public void OpenAbout()
    {
        if ( AboutWindow.IsOpen ) return;
        AboutWindow win = new AboutWindow();
        win.Show();
    
    }
