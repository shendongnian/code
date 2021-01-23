    int count = (from p in _db.SubMenus
                 where p.UrlName == urlName
                 select p).Count();
    if (count == 0)
    {
        // add new record here
    }
    else if (count == 1)
    {
        TryUpdateModel(existingMenu);
        _menu.Add();
    }
    else if (count > 1)
    {
        // take action on having a duplicate here.
    }
    
