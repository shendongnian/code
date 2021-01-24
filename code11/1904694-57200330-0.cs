    private StorageFileQueryResult resultSet;
    private async Task EnableChangeTracker()
    {
        StorageLibrary picsLib = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Pictures);
        StorageLibraryChangeTracker picTracker = picsLib.ChangeTracker;
        picTracker.Enable();
        List<string> supportExtension = new List<string>();
        supportExtension.Add(".png");
        supportExtension.Add(".jpg");
        StorageFolder photos = KnownFolders.PicturesLibrary;
        // Create a query containing all the files your app will be tracking
        QueryOptions option = new QueryOptions(CommonFileQuery.DefaultQuery, supportExtension);
        option.FolderDepth = FolderDepth.Shallow;
        // This is important because you are going to use indexer for notifications
        option.IndexerOption = IndexerOption.UseIndexerWhenAvailable;
        resultSet = photos.CreateFileQueryWithOptions(option);
        // Indicate to the system the app is ready to change track
        // Attach an event handler for when something changes on the system
        resultSet.ContentsChanged += ResultSet_ContentsChanged;
        await resultSet.GetFilesAsync();
    }
