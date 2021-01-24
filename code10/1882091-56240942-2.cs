    var allItems = await graphClient.Me.Drive.List.Items.Request().Expand( i => i.DriveItem).GetAsync();
    foreach (var item in allItems)
    {
         Console.WriteLine(item.DriveItem.Name); //print name
    }
