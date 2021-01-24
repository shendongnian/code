    public interface IGenericRepository<TEntity>
      where TEntity: class 
    { } 
    public class GenericRepository<TEntity> 
      where TEntity:class, IGenericRepository<TEntity>
    { }
