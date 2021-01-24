    private async void Loadbtn_Click(object sender, RoutedEventArgs e)
    {
        var picker = new Windows.Storage.Pickers.FileOpenPicker();
        picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
        picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.MusicLibrary;
        picker.FileTypeFilter.Add(".mp3");
        picker.FileTypeFilter.Add(".wav");
        picker.FileTypeFilter.Add(".mp4");
    
        var files = await picker.PickMultipleFilesAsync();
        if (files.Count > 0)
        {
          
            foreach (StorageFile file in files)
            {
                var item = new MediaItem { File = file, FileName = file.Name };
                comboBox.Items.Add(item);
            }
    
        }
        else
        {
            throw new Exception("Operation cancelled");
        }
    }
    
    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var mediaitem = comboBox.SelectedItem as MediaItem;
        mediaPlayerElement.MediaPlayer.SetFileSource(mediaitem.File);
    }
