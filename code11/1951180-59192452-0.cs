    public interface IDbEntity {
        int Id { get; }
    }
    ...
    
    public static TDbEntity[] GetByIds<TDbEntity>(this IQueryable<TDbEntity> queryable, int[] ids)
        where TDbEntity : class, IDbEntity
    {
        return queryable.Where(e => ids.Contain(e.Id)).ToArray();
    }
