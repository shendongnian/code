    public class RowMapperCache
    {
        private Dictionary<Type, object> cache = new Dictionary<Type, object>();
        private object locker = new object();
        public IRowMapper<T> GetCachedMapper<T>() where T : new()
        {
            Type type = typeof(T);
            lock (locker)
            {
                if (!Contains(type))
                {
                    cache[type] = MapBuilder<T>.BuildAllProperties();
                }
            }
            return cache[type] as IRowMapper<T>;
        }
        private bool Contains(T type)
        {
            return cache.ContainsKey(type);
        }
    }
     // retrieve default mapper and cache it
     IRowMapper<Region> regionMapper = rowMapperCache.GetCachedMapper<Region>();
     var db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
     var r = db.ExecuteSqlStringAccessor<Region>("SELECT * FROM Region", regionMapper);
