    public class CrudRepository<TEntity>
    {
        DbEntities db = new DbEntities();
        public override void Create(TEntity entity)
        {
            db.CreateObjectSet<TEntity>().AddObject(entity);
        }
    }
