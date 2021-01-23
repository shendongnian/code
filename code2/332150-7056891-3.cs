    public class MyContext : DbContext
    {
        public override int SaveChanges()
        {
            //intercept entity changes
            UnderlyingObjectContext.ObjectStateManager.ObjectStateManagerChanged 
               += OnObjectStateManagerChanged;
    
            var changedEntities = ChangeTracker.Entries();
    
            foreach (var changedEntity in changedEntities)
            {
                if (changedEntity.Entity is Entity)
                {
                    var entity = (Entity)changedEntity.Entity;
    
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.OnBeforeInsert();
                            break;
    
                        case EntityState.Modified:
                            entity.OnBeforeUpdate();
                            break;
                    }
                }
            }
    
            return base.SaveChanges();
        }
    
        ObjectContext UnderlyingObjectContext
        {
             get
             {
                  return ((IObjectContextAdapter)this).ObjectContext;
             }
        }
    
        void OnObjectStateManagerChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Add)
            {
                 //not all added entities are new
                 if (UnderlyingObjectContext.ObjectStateManager
                   .GetObjectStateEntry(e.Element).State == EntityState.Added)
                 {
                       if (e.Element is Entity)
                       {
                           ((Entity)e.Element).OnBeforeInsert();
                       }
                 }
            }
         }
    }
