    StorageFolder externalDevices = Windows.Storage.KnownFolders.RemovableDevices; 
    StorageFolder sdCard = (await externalDevices.GetFoldersAsync()).FirstOrDefault();
    
    if (sdCard != null)
    {
        var rootFolder = await sdCard.GetFoldersAsync();
        var folder = rootFolder[0];
        var picker = new FileOpenPicker
        {
            FileTypeFilter = { ".jpg", ".png", ".gif", ".txt" },
            SuggestedStartLocation = PickerLocationId.PicturesLibrary
        };
        var sourceFile = await picker.PickSingleFileAsync();
        if (sourceFile != null)
        {
            var newfile = await sourceFile.CopyAsync(folder, sourceFile.Name, NameCollisionOption.ReplaceExisting);
        }
    }
    else
    {
        // No SD card is present.
    }
  
