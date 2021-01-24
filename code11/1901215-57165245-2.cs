    var sharedItem = await graphClient.Drives[driveId].Items[folderItemId].Request().Expand(i => i.Children).GetAsync();
    foreach (var item in sharedItem.Children)
    {
        if (item.File != null)
        {
            var fileContent = await graphClient.Drives[item.ParentReference.DriveId].Items[item.Id].Content.Request()
                        .GetAsync();
            using (var fileStream = new FileStream(item.Name, FileMode.Create, System.IO.FileAccess.Write))
               fileContent.CopyTo(fileStream);
        }
    }
