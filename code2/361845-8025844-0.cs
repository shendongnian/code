    foreach (Property P in Results)
    {
      if(P.PropertyId==0 && P.EntityState==EntityState.Added)
      {
        var id = Repository.Properties.Max(p => (int?)p.PropertyId) ?? 0;
        P.PropertyId=++id;
        Repository.Properties.AddObject(P);
        Repository.SaveChanges();
      }
    }
