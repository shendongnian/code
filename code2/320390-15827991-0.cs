    // if the property is not loaded yet, first load it
    mail.Load(PropertySet(BasePropertySet.IdOnly, EmailMessageSchema.IsRead));
    
    if (!mail.IsRead) // check that you don't update and create unneeded traffic
    {
      mail.IsRead = true; // mark as read
      mail.Update(ConflictResolutionMode.AutoResolve); // persist changes
    }
