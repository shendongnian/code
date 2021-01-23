    public abstract class Entity : IComparable
    {
        protected int _ID;
        public abstract int ID { get; }
    }
    public abstract class SortedEntities<TEntities, TEntity> : IEnumerable<TEntity>
        where TEntities : SortedEntities<TEntities, TEntity>, new()
        where TEntity : Entity
    {
        Dictionary<int, TEntity> _Entities;
        public TEntities GetFromIDList(string IDCSV)
        {
            List<string> ids = IDCSV.Split(',').ToList<string>();
            return new TEntities
            {
                _Entities = this.Where(entity => ids.Contains(entity.ID.ToString()))
                                .ToDictionary(e => e.ID)
            };
        }
    }
