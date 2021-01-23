var properties = typeof(TEntity).GetProperties();
foreach (var property in properties)
{
    if (property.GetCustomAttributes(typeof(OneToManyAttribute), false).Length > 0)
    {
        dynamic collection = db.Entry<TEntity>(e).Collection(property.Name).CurrentValue;
        foreach (var item in collection)
        {
            if(item.GetType().IsSubclassOf(typeof(Entity))) 
            {
                if (item.Id == 0)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                else
                {
                    db.Entry(item).State = EntityState.Modified;
                }
             }
        }
    }
}
db.Entry<TEntity>(e).State = EntityState.Modified;            
db.SaveChanges();
