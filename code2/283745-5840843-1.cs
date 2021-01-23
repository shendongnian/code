    public override int SaveChanges(SaveOptions options)
    {
        var data = context.ObjectStateManager
                          .GetObjectStateEntries(EntityState.Added | EntityState.Modified)
                          .Where(e => !e.IsRelationship)
                          .Select(e => e.Entity)
                          .OfType(MyEntity);
 
        foreach(var entity in data)
        {
            if (entity.CertificateId == null)
            {
                entity.CertificateId = String.Empty;
            }
        }
        return base.SaveChanges(options);
    }
