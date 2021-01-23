    public override int SaveChanges()
    {
        var changeSet = ChangeTracker.Entries<IAuditable>();
    
        if (changeSet != null)
        {
            foreach (var entry in changeSet.Where(c => c.State != EntityState.Unchanged))
            {
                entry.Entity.ModifiedDate = DateProvider.GetCurrentDate();
                entry.Entity.ModifiedBy = HttpContext.Current.User.Identity.Name;
            }
        }
        return base.SaveChanges();
    }
