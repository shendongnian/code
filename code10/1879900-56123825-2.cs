    var activityItems = await ActivityConnection.Table<ActivityTable>().ToListAsync();
    var CAFItems = await CafConnection.Table<CAFActivityTable>().ToListAsync();
    
    foreach (var item in activityItems)
    {
        foreach (var CAFItem in CAFItems)
        {
            if (item.ActivityID == CAFItem.ActivityID)
            {
                item.Selected = true;
                break;
            }
        }
    }
    // Bind your list view's items source to this activityItems
    // If you want to update the database use the code below
    await ActivityConnection.UpdateAllAsync(activityItems);
