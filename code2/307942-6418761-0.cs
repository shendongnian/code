    public class Repository<TEntity>
    {
       public IEnumerable<TEntity> GetCollection(Expression<Func<TEntity, bool>> filter, 
          int pageSize, int pageIndex)
       {
          return YourDbSet.Where(filter).OrderBy(sortExpression).Skip(pageSize * pageIndex).Take(pageSize);
       }
    
       public int Count(Expression<Func<TEntity, bool>> filter)
       {
          return YourDbSet.Where(filter).Count();
       }
    }
