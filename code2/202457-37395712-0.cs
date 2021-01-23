      public App()
        {            
            ShutdownMode = System.Windows.ShutdownMode.OnMainWindowClose;  
        }
    private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
