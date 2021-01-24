            switch (i)
            {
                case 1:
                    closeToOpen();
                    openToClose();
                    break;
                case 2:
                    openToClose();
                    closeToOpen();
            default:
                    break;
            }
        }
        void openToClose()
        {
            mediaPlayerElement.Source = null;
            openButton.Content = "Open";
        }
        void closeToOpen()
        {
            FileOpenPicker filePicker = new FileOpenPicker();
            //Add filetype filters.  In this case wmv and mp4.
            filePicker.FileTypeFilter.Add(".wmv");
            filePicker.FileTypeFilter.Add(".mp4");
            filePicker.SuggestedStartLocation = PickerLocationId.VideosLibrary;
            StorageFile file = await filePicker.PickSingleFileAsync();
            if (file != null)
            {
                mediaPlayerElement.Source = MediaSource.CreateFromStorageFile(file);
                mediaPlayerElement.MediaPlayer.Play();
            }
            openButton.Content = "Close";
        }
