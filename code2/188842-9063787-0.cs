    WinList list;
    UITestControlCollection columns = websitesList.Columns; // Get Columns names
    // Get values
    foreach (WinControl item in list.Items)
       {
            WinListItem listItem = new WinListItem(item);
            string[] subItems = WinExtensions.GetColumnValues(listItem); // So you get value = subitem[i] in column[i]
       }
