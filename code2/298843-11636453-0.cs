    db.Products.Attach(product);
    var entry = db.Entry(product);
    entry.State = EntityState.Unchanged;
    entity.Property(p => p.Overview).IsModified = true;
    entity.Property(p => p.Description).IsModified = true;
    db.SaveChanges();
