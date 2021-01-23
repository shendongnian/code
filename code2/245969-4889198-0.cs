    public interface IRepository<T> where T: IProduct
    {
       IEnumerable<T> Search(Predicate<T> query)
       IEnumerable<T> Search(IEnumerable<Predicate<T>> query>
       
    }
