    bool exists = (from p in _db.SubMenus
                   where p.UrlName == urlName
                   && p.Id == currentId
                   select p).Any()
    if (!exists)
    {
        TryUpdateModel(existingMenu);
        _menu.Add();
    }
    else
    {
        // throw exception
    }
    
