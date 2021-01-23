    private void SaveUser(User user)
    {
        _db.USERs.Attach(user);
        ObjectStateEntry entry = _db.ObjectStateManager.GetObjectStateEntry(user);
        entry.SetModifiedProperty("PropertyName");
        // set other properties
        _db.SaveChanges();
    }
