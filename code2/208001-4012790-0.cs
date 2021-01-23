    public interface IRepository<TEntity>
    {
        void Delete(TEntity entity);
        /* ... */
    }
    public abstract class AbstractRepository<TEntity> : IRepository<TEntity>
    {
        public TemplateEntities ctx;
        public AbstractRepository(IUnitOfWork unit)
        {
            ctx = unit as TemplateEntities;
        }
        protected abstract ObjectSet<TEntity> Entites { get; }
        public virtual void Delete(TEntity entity)
        {
            Entities.Attach(entity);
            ctx.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Deleted);
        }
        /* ... */
    }
    public interface IUserRepository : IRepository<User>
    {
        User GetUser(string username);
        /* ... */
    }
    public class UserRepository : AbstractRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unit)
            : base(unit)
        {
        }
        protected override ObjectSet<User> Entites
        {
            get { return ctx.Users; }
        }
        public User GetUser(string username)
        {
            return (from u in ctx.Users
                    where u.UserName == username
                    select u).SingleOrDefault();
        }
        /* ... */
    }
