    private async void ListOption_ItemClick(object sender, ItemClickEventArgs e)
    {
        FileOpenPicker openPicker = new FileOpenPicker();
        openPicker.ViewMode = PickerViewMode.Thumbnail;
        openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
        openPicker.FileTypeFilter.Add(".jpg");
        openPicker.FileTypeFilter.Add(".jpeg");
        openPicker.FileTypeFilter.Add(".png");
    
        StorageFile file = await openPicker.PickSingleFileAsync();
        if (file != null)
        {
            StorageFile fileForView = await file.CopyAsync(ApplicationData.Current.TemporaryFolder, file.Name, NameCollisionOption.ReplaceExisting);
            Image = new BitmapImage(new Uri(fileForView.Path));
            TestImg.Source = Image;
        }
        else
        {
    
        }
    }
