    private void ArtaDoITButton_Click(object sender, RoutedEventArgs e)
    {
      if (File.Exists("settings.xml"))
      {
        await LoadPageAsync();
      }
      else
      {
        MessageBox.Show("Chybí settings file!!");
      }
    }
  
    private async Task LoadPageAsync()
    {
      await Task.Run(
        () =>
        {
          var xs = new XmlSerializer(typeof(Information));
          using (var read = new FileStream("settings.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
          {
            Information info = (Information) xs.Deserialize(read);
            try
            {
              string a = info.FtpPassword;
              string FTPPassword = EncryDecryptor.Decrypt(a);
              bool TestFTP = General_Functions.isValidConnection(info.HDSynologyIP, info.FtpUsername, FTPPassword);
              if (TestFTP == true)
              {
                ArtaActionsFrame.Content = new ArtaActionsPage();
              }
              else
              {
                MessageBox.Show("Failed login to FTP repozitary. Check your credentials in settings.");
              }
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.ToString());
            }
          }
        });
    }
