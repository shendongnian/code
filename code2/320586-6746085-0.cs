    public class IHasId
    {
        public int id { get; set; }
    }
    public interface IGenericRepository<T>
    {
        int id { get; }
        T GetById(int id);
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : IHasId
    {
        public int id
        {
            get { throw new NotImplementedException(); }
        }
        public T GetById(int id)
        {
            return from tbl in dataContext.GetTable<T> where tbl.id == tid select tbl;
        }
    }
