    using (hydraEntities db = new hydraEntities())
    {
        db.youusers.Attach(YouUser);
        db.ObjectStateManager.ChangeObjectState(YouUser, System.Data.EntityState.Modified);
        db.SaveChanges();
    }
