    private async void ArtaDoITButton_Click(object sender, RoutedEventArgs e)
    {
      if (!File.Exists("settings.xml"))
      {
        MessageBox.Show("Chybí settings file!!");
        return;
      }
      var nextPage = new ArtaActionsPage();
      // Show the page immediately
      ArtaActionsFrame.Content = nextPage;
      if (!await nextPage.TryInitializeAsync())
      {
        MessageBox.Show("Failed login to FTP repozitary. Check your credentials in settings.");
        // Show previous page again
      }
    }
