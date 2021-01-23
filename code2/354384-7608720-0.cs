    public override int SaveChanges(SaveOptions options)
    {    
        foreach (ObjectStateEntry entry in
            ObjectStateManager.GetObjectStateEntries(EntityState.Modified))
        {
            var v = entry.Entity as IVersionedRow;
            if(v != null) v.RowVersion++;
        }
        return base.SaveChanges(options);
    }
