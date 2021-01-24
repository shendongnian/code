    private async void YourMethod()
    {
        ......
        IReadOnlyList<StorageFolder> MyList = await MyStorageFolder.GetFoldersAsync();
        if (MyList.Count > 0)
        {
            Debug.WriteLine("SubFolder exists.");
        }
    }
