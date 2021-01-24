    FolderPicker folderPicker = new FolderPicker();
    folderPicker.ViewMode = PickerViewMode.List;
    folderPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
    folderPicker.FileTypeFilter.Add("*");
    var folder = await folderPicker.PickSingleFolderAsync();
    foreach (var files in await folder.GetFilesAsync())
    {
        Debug.WriteLine(files.DisplayName);
    }
