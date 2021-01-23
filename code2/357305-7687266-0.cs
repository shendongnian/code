     //Going through first level items
     if (e.item.NavigateUrl == "")
        e.item.Enabled = false;
     //Going through submenu item
    foreach (MenuItem item in e.Item.Items)
    {
         if (item.NavigateUrl == "")
             item.Enabled = false;
    }
