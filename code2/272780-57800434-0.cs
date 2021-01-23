            foreach(var e in updateEntity)
            {
                context.Set<T2>().InsertOrUpdate(e);
            }
        }
        public static void InsertOrUpdate<T, T2>(this T entity, T2 updateEntity) 
        where T : class
        where T2 : class
        {
            if (context.Entry(updateEntity).State == EntityState.Detached)
            {
                if (context.Set<T2>().Any(t => t == updateEntity))
                {
                   context.Set<T2>().Update(updateEntity); 
                }
                else
                {
                    context.Set<T2>().Add(updateEntity);
                }
                
            }
            context.SaveChanges();
        }
