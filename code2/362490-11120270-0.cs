    var oldMenu_HideItems = Menu_HideItems;   
    if(oldMenu_HideItems)
    {
            Menu_HideItems = function(items)
            {
                    try
                    {
                      return oldMenu_HideItems(items);
                    }
                    catch(err)
                    {
                    }
             }
    } 
