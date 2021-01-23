    public class CrudRepository<TEntity> where TEntity : class
    {
        DbEntities db = new DbEntities();
        public override void Create(TEntity entity)
        {
            db.CreateObjectSet<TEntity>().AddObject(entity);
        }
    }
