    public interface IRepository {
        ValueForEntity GetValueForEntity(int v);
        void InsertValueForEntity(int v, ValueForEntity valueForEntity);
    }
    public class RealRepository : IRepository {
        private readonly IDictionary<int, ValueForEntity> data = new Dictionary<int, ValueForEntity>();
        public ValueForEntity GetValueForEntity(int v) => data[v];
        public void InsertValueForEntity(int v, ValueForEntity valueForEntity) => data[v] = valueForEntity;           
    }
    public class ValueForEntity {
        public int Id { get; set; }
    }
