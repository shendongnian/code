    public void AddPersonToList(int id, int toAdd)
    {
      var mailList = new MailList { ID = id, ContactInformations = new List<ContactInformation>() };
      this.db.MailLists.Attach(mailList);
      var ci = new ContactInformation { ID = toAdd };
      this.db.ContactInformations.Attach(ci);
      this.db.ObjectStateManager.ChangeRelationshipState(mailList, ci, ml => ml.ContactInformations, System.Data.EntityState.Added);
    }
