    // migrate temp profile(s)...
    var tempProfilesToMigrate = (from ct in db.contact_temps
                                 where ct.SessionKey == contact.Profile.SessionId
                                 select new contact()).ToArray();
    foreach (var c in tempProfilesToMigrate)
    {
        Contact newC = new Contact();
        newC.Name = c.Name;
        // copy other values
        db.contacts.InsertOnSubmit(newC);
    }
    // WAIT! do it at once in a single TX db.SubmitChanges();
    //...clear temp table records
    var tempProfilesToDelete = from ct in db.contact_temps
                               where ct.SessionKey == contact.Profile.SessionId
                               select ct;
     db.contact_temps.DeleteAllOnSubmit(tempProfilesToDelete);
     
     // Both sets of changes in one Tx.
     db.SubmitChanges();
