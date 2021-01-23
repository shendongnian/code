    public class Repository<T> : IRepository<T>
        where T : class, IEntity
    {
        DataContext _db;
        public Repository()
        {
            _db = new DataContext("Database string connection");
            _db.DeferredLoadingEnabled = false;
        }
        public void Add(T entity)
        {
            if (!Exists(entity))
                GetTable.InsertOnSubmit(entity);
            else
                Update(entity);
            SaveAll();
        }
        public void Delete(T entity)
        {
            GetTable.DeleteOnSubmit(entity);
            SaveAll();
        }
        public void Update(T entity)
        {
            GetTable.Attach(entity, true);
            SaveAll();
        }
        System.Data.Linq.Table<T> GetTable
        {
            get { return _db.GetTable<T>(); }
        }
        public IEnumerable<T> All()
        {
            return GetTable;
        }
    }
