    public interface ILookup
    {
        int Id { get; set; }
        string FR { get; set; }
        string NL { get; set; }
        string EN { get; set; }
        bool IsActive { get; set; }
    }
    public class LookupA : ILookup
    {
    }
    public class LookupB : ILookup
    {
    }
    public interface ILookupRepository<T>
    {
        IList<T> GetList();
    }
    public class LookupRepository<T> : ILookupRepository<T> where T : ILookup
    {
        public IList<T> GetList()
        {
            List<T> list = Session.Query<T>().Where(y => y.IsActive).ToList<T>();
            return list;
        }       
    }
