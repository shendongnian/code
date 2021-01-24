    private async void ArtaDoITButton_Click(object sender, RoutedEventArgs e)
    {
      if (File.Exists("settings.xml"))
      {
        var nextPage = new ArtaActionsPage();
        // Show the page immediately
        ArtaActionsFrame.Content = nextPage;
        bool pageInitializationSuccessful = await nextPage.InitializeAsync();
        
        if (!pageInitializationSuccessful)
        {
          MessageBox.Show("Failed login to FTP repozitary. Check your credentials in settings.");
          // Show previous page again
        }
      }
      else
      {
        MessageBox.Show("Chybí settings file!!");
      }
    }
