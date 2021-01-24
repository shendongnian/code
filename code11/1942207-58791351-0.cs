        private async void mainGrid_Drop(object sender, DragEventArgs e)
        {
            Image img = new Image();
            img.Width = 200;
            img.Height = 150;
            BitmapImage bm = new BitmapImage();
            MediaPlayerElement mediaPlayerElement = new MediaPlayerElement();
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var storageItems = await e.DataView.GetStorageItemsAsync();
                foreach (StorageFile file in storageItems)
                {
                    if (file.FileType == ".mp4")
                    {
                        mediaPlayerElement.Source = MediaSource.CreateFromStorageFile(file);
                        mainGrid.Children.Add(mediaPlayerElement);
                    }
                    else
                    {
                        var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                        await bm.SetSourceAsync(stream);
                        img.Source = bm;
                        mainGrid.Children.Add(img);
                    }
                }
            }
        }
