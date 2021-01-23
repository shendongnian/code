      foreach (var item in needDeleted) {
        //have to use the datacontext directly.  I desperately want this gone!
        db.ContactInformations.Remove(db.ContactInformations.Single(c => c.ContactInformationId == item.ContactInformationId));
        //This will produce the same error as UpdateModel(contact)
        //contact.ContactInformations.Remove(contact.ContactInformations.SingleOrDefault(c => c.ContactInformationId == item.ContactInformationId));
      }
