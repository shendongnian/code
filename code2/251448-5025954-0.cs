        public void AddAndRemovePersons(int id, int[] toAdd, int[] toDelete)
        {
            var mailList = new MailList { ID = id, ContactInformations = new List<ContactInformation>() };        
            this.db.MailLists.Attach(mailList);
            foreach (var item in toAdd)
            {
                var ci = new ContactInformation { ID = item };
                this.db.ContactInformations.Attach(ci);
                this.db.ObjectStateManager.ChangeRelationshipState(mailList, ci, ml => ml.ContactInformations, System.Data.EntityState.Added);
            }
            foreach (var item in toDelete)
            {
                var ci = new ContactInformation { ID = item };
                this.db.ContactInformations.Attach(ci);
                this.db.ObjectStateManager.ChangeRelationshipState(mailList, ci, ml => ml.ContactInformations, System.Data.EntityState.Deleted);
            }
        }
