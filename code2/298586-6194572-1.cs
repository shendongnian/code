    // migrate temp profile(s)...
    var tempProfiles = from ct in db.contact_temps
                                 where ct.SessionKey == contact.Profile.SessionId
                                 select ct;
    foreach (var c in tempProfiles)
    {
        Contact newC = new Contact();
        newC.Name = c.Name;
        // copy other values
        db.contacts.InsertOnSubmit(newC);
    }
    // WAIT! do it at once in a single TX => avoid db.SubmitChanges() here.
     db.contact_temps.DeleteAllOnSubmit(tempProfiles);
     // Both sets of changes in one Tx.
     db.SubmitChanges();
