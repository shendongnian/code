      foreach (var item in needDeleted) {
        var ci = contact.ContactInformations.Single(c => c.ContactInformationId == item.ContactInformationId);
        contact.ContactInformations.Remove(ci); // 1
        db.ContactInformations.Remove(ci);      // 2
      }
