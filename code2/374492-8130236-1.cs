    public abstract class BaseRepository<TModel, TEntities> where TEntities : IDbSet<TModel>
    {
        protected TEntities Entities {get; set;}
        protected DbContext Db {get; set;}
        public BaseRepository (DbContext db, TEntities entities)
        {
            Db = db;
            Entities = entities;
        }
        public virtual TModel Create() { return Entities.Create (); }
        public virtual TModel Retrieve (params object[] keys) { return Entities.Find (keys); }
        public virtual void Update (TModel existing) { Db.Entry(existing).State = Modified; }
        public virtual void Delete (TModel existing) { Db.Entry(existing).State = Removed; }
    }
