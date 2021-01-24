    static async Task GetAllChildren(IDriveRequestBuilder drive,List<DriveItem> result, IDriveItemRequestBuilder root = null)
    {
        root = root ?? drive.Root;
        var items = await root.Children.Request().GetAsync();
        result.AddRange(items.ToList());
        foreach (var item in items)
        {
            if (item.Folder != null && item.Folder.ChildCount > 0)
            {
                await GetAllChildren(drive, result, drive.Items[item.Id]);
            }
        }
    }
