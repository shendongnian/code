    public class EntityBase<TId>
    {
        public TId Id {get; set;}
    }
    public interface IRepository<TId>
    {
        Task<PayoutResult> Insert(EntityBase<TId> entity);
        bool EntityExists(EntityBase<TId> entity);
    }
