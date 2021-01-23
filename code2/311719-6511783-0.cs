    public void UpdateOrModify<T>(T entity, string key) where T : class, IEntity // Implements MyKey 
    {
         using (var context = new MyContainer())
         {
             if (context.Set<T>().Any(e => e.MyKey == key))
             {
                  context.Entry(entity).State = EntityState.Modified;
             } 
             else
             {
                  context.Entry(entity).State = EntityState.Added;
             }
             context.SaveChanges();
         }
    }
