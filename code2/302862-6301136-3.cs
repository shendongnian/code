    private void Update(string urlName, string display, bool active)
    {
        item = db_.SubMenus.SingleOrDefault(x => x.UrlName == urlName);
        
        if (item == null)
        {
            // Save new item here
        }
        else
        {
            if (item.DisplayName == display && item.Active == active)
            {
                // Error, fields haven't changed and url already in db
            }
            else
            {
                // Save because fields have changed
            }
        }
    }
