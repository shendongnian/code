    progressBar.IsIndeterminate = true;
    progressBar.Visibility = Visibility.Visible;
    string s = txtInputLink.Text;
    await Task.Run(() => youtubeConverter.ConvertVideoAndDownloadToFolder(s));
    progressBar.Visibility = Visibility.Collapsed;
