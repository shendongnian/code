    interface IRepositry<T>
    {
     T GetById(long id);
     bool Save(T entity);
    }
    public class Repository<T> : IRepository<T> {...}
    var repository = new Repository<MyEntity>();
    var myEntity = repository.GetById(1);
    var repository2 = new Repository<MySecondEntity>();
    var mySecondEntity = repository.GetById(1);
