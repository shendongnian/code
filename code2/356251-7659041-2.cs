    var myMailings = db_creator.Create().Mailing.Where(it => !it.mail_IsSent).ToList();
    ... // make modifications and retrieve coll a collection of Mailing objects
    using (var db = db_creator.Create()) {
      ... // if you want to further modify the objects in coll you should do this before writing it to the context
      foreach (Mailing it in coll) {
        if (it.EntityKey != null) db.GetObjectByKey(it.EntityKey); // load entity
        else db.Mailing.Single(x => x.YourId == it.YourId); // load the entity when EntityKey is not available, e.g. because it's a POCO
        db.Mailing.ApplyCurrentValues(it); // sets the entity state to Modified
      }
      db.SaveChanges();
    }
