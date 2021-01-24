    private void Button_Click(object sender, RoutedEventArgs e)
    {
    
        if (!fullScreen)
        {
            mainPageBackup = this.Frame;
            Window.Current.Content = MyFrame;     
            ApplicationView.GetForCurrentView().TryEnterFullScreenMode();              
            fullScreen = true;
        }
        else
        {          
            Window.Current.Content = mainPageBackup;                  
            ApplicationView.GetForCurrentView().ExitFullScreenMode();            
            fullScreen = false;
        }
    }
