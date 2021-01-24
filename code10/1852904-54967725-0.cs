    using (var db = new EntityContext())
    {
        var ent = db.Entities.Where(x => x.ID == 1 && x.LOGIN == null).FirstOrDefault(); 
        if (ent != null)
        {
            ent.LOGIN = "Whatever";
            ent.EMAIL = "Whatever";
        }
        else
        {
            db.Entities.Add(ent);
        }
        db.SaveChanges();
    }
