    public abstract class BaseRepository<T> : IEntityBaseRepository<T> where T : class, new()
    {
        public virtual IEnumerable<T> items => throw new NotImplementedException();
        public virtual T GetSingle(int id)
        {            
            throw new NotImplementedException();
        }
    }
    public class EntityBaseRepository<T> : BaseRepository<T> where T : class
                                                 , IFullAuditedEntity, new()
    {
        public override IEnumerable<T> items => base.items;
        public override T GetSingle(int id)
        {
            return base.GetSingle(id);            
        }
    }
