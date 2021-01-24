    if (item.Locking.IsLocked() && item.Access.CanWrite())
    {
        using (new Sitecore.SecurityModel.SecurityDisabler())
        {
            item.Locking.Unlock();
        }
    }
