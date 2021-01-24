where TEntity : class
public class GenericEntityImplementation<K, TEntity, TDbContext> : 
        IGenericEntity<K, TEntity> where TDbContext : DbContext where TEntity : class
{
}
