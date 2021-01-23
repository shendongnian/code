    public abstract class GenericAccess<TEntity> where TEntity : IEntity, new()
    {
        public static IList<TEntity> GetObjectListFromArray(int[] IDs)
        {
            return IDs.Select(id => new TEntity { Id = id }).ToList();
        }
    }
