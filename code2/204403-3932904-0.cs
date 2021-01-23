    public class EntityList<T> : Dictionary<string, T>, IDataSetStorable where T : AbstractDataEntity
    {
        public void AddEntity(T entity)
        {
            this.Add(entity.ID, entity);
        }
        public T RetrieveEntity(string id)
        {
            return this[id];
        }
    }
