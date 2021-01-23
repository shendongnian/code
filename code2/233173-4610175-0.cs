    foreach (var item in ListBox.Items)
    {
        if (item.Text.Contains(searchArg))
        {
            //select this item in the ListBox.
            ListBox.SelectedValue = item.Value;
            break;
        }
    } 
