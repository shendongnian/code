    void dl_DownloadStringCompleted2(object sender, DownloadStringCompletedEventArgs e)
    {
        progress.Visibility = Visibility.Collapsed;
        progress.IsIndeterminate = false;
        ...
    }
      
