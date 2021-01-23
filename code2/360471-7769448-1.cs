    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.Entity;
    using System.Data;
    
    namespace Nodes.Data.Repository
    {
        public class BaseRepository<TEntity>:IRepository<TEntity> where TEntity : class
        {
            internal SampleDBContext context;
            internal DbSet<TEntity> dbSet;
    
            public BaseRepository(SampleDBContext context)
            {
                this.context = context;
                this.dbSet = context.Set<TEntity>();
            }
    
            public virtual TEntity GetByID(object id)
            {
                return dbSet.Find(id);
            }
    
            public virtual void Insert(TEntity entity)
            {
                dbSet.Add(entity);
    
            }
    
            public virtual void Delete(object id)
            {
                TEntity entityToDelete = dbSet.Find(id);
                Delete(entityToDelete);
            }
    
            public virtual void DeleteAll(List<TEntity> entities)
            {
                foreach (var entity in entities)
                {
                    this.Delete(entity);
                }
            }
    
            public virtual void Delete(TEntity entityToDelete)
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
            }
    
            public virtual void Update(TEntity entityToUpdate)
            {
                dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
            }
    
            public IQueryable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
            {
                return dbSet.Where(predicate);
            }
        }
    }
