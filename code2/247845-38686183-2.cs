     public class Repository<TContext>: IDataRepository
           
           where TContext:DbContext,new ()
       {
         
            protected static void ExecuteAsync<T>(Func<List<T>> task, Action<List<T>> callback, Action<Exception> exceptionCallback = null) where T : EntityBase
            {
                var worker = new BackgroundWorker();
                worker.DoWork += (s, e) =>
                {
                    e.Result = task();
                };
                worker.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Error == null && callback != null)
                        callback((List<T>)e.Result);
                    else if (e.Error != null && exceptionCallback != null)
                        exceptionCallback(e.Error);
                };
                worker.RunWorkerAsync();
            }
    
            protected static void ExecuteAsync<T>(Func<T> task, Action<T> callback, Action<Exception> exceptionCallback = null) where T : EntityBase
            {
                var worker = new BackgroundWorker();
                worker.DoWork += (s, e) =>
                {
                    e.Result = task();
                };
                worker.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Error == null && callback != null)
                        callback((T)e.Result);
                    else if (e.Error != null && exceptionCallback != null)
                        exceptionCallback(e.Error);
                };
                worker.RunWorkerAsync();
            }
    
            protected static void ExecuteAsync(Action task, Action callback, Action<Exception> exceptionCallback = null)
            {
                var worker = new BackgroundWorker();
                worker.DoWork += (s, e) =>
                {
                   task();
                };
                worker.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Error == null && callback != null)
                        callback();
                    else if (e.Error != null && exceptionCallback != null)
                        exceptionCallback(e.Error);
                };
                worker.RunWorkerAsync();
            }
    
    
            public void AddAsync<T>(T entity, Action<T> callBack, Action<Exception> exceptionCallback = null) where T : EntityBase
            {
                ExecuteAsync(() =>
                {
                    using (var context = new TContext())
                    {
                       var addedEntity = context.Set<T>().Add(entity);
                        context.SaveChanges();
                        return addedEntity;
                    }
                },callBack,exceptionCallback);
                
           }
    
           public void DeleteAsync<T>(int[] ids, Action callBack, Action<Exception> exceptionCallback = null) where T : EntityBase
            {
                ExecuteAsync(() =>
                {
                    using (var context = new TContext())
                    {
                       var entitiesToRemove = context.Set<T>().Where(x => ids.Contains(x.Id)).ToList();
                        foreach (var entity in entitiesToRemove)
                        {
                            context.Entry(entity).State=EntityState.Deleted;
                        }
                        context.SaveChanges();                    
                    }
                },callBack, exceptionCallback);
            }
    
           public void UpdateAsync<T>(T entity, Action<T> callBack, Action<Exception> exceptionCallback = null) where T : EntityBase
            {
               ExecuteAsync(() =>
               {
                   using (var context=new TContext())
                   {
                     context.Entry(entity).State=EntityState.Modified;
                       context.SaveChanges();
                       var updatedEntity = context.Set<T>().Find(entity.Id);
                       return updatedEntity;
                   }
               },callBack,exceptionCallback);
           }
    
           public void FindAsync<T>(int id, Action<T> callBack, Action<Exception> exceptionCallback = null) where T : EntityBase
            {
               ExecuteAsync(() =>
               {
                   using (var context=new TContext())
                   {
                       var entity = context.Set<T>().Find(id);
                       return entity;
                   }
               },callBack,exceptionCallback);
           }
    
           public void FindAsync<T>(Action<List<T>> callBack, Expression<Func<T, bool>> predicate=null, int? pageIndex = 0, int? pageSize = 20, params Expression<Func<T, object>>[] includes) where T : EntityBase
            {
               ExecuteAsync(() =>
               {
                   using (var context=new TContext())
                   {
                       var query = context.Set<T>().AsQueryable();
    
                       if (includes != null)
                       {
                           query = includes.Aggregate(query, (current, include) => current.Include(include));
                       }
                       if (predicate != null)
                           query = query.Where(predicate);
    
                       var offset = (pageIndex ?? 0) * (pageSize ?? 15);
                       query = query.OrderBy(x=>x.Id).Skip(offset).Take(pageSize ?? 15);
    
                       return query.ToList();
                   } 
               },callBack);
           }
       }
