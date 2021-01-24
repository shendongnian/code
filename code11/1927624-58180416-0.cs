     public int Update(T entity)
        {
         context.Entry(entity).State = EntityState.Modified;
         return context.SaveChanges();
        }
