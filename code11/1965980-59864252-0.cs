    progressBar.IsIndeterminate = true;
    progressBar.Visibility = Visibility.Visible;
    string s = txtInputLink.Text;
    Task.Factory.StartNew(() => youtubeConverter.ConvertVideoAndDownloadToFolder(s))
        .ContinueWith(_ => progressBar.Visibility = Visibility.Collapsed,
            CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
