    /// <summary>
    /// Updates the UI after the albums have been retrieved. This prevents the annoying delay when receiving the albums list.
    /// </summary>
    /// <param name="albums"></param>
    public void UpdateUiAfterAlbumsRetrieved(System.Collections.ObjectModel.ObservableCollection<PhotoAlbum> albums)
    {
        if (!Dispatcher.HasThreadAccess)
        {
            Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                ddlAlbums.DataContext = albums;
                ddlAlbums.IsEnabled = true;
                tbxProgress.Text = String.Empty;
                ProgressBar.IsIndeterminate = false;
                ProgressBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            });
        }
        else
        {
            ddlAlbums.DataContext = albums;
            ddlAlbums.IsEnabled = true;
            tbxProgress.Text = String.Empty;
            ProgressBar.IsIndeterminate = false;
        }
    }
