    public interface ICovariant<out T> where T : BaseModel
    {
    }
    public abstract class BaseModel { }
    public class NewModel : BaseModel { }
    public class BaseRepo<T> : ICovariant<T> where T : BaseModel { }
    class NewRepo : BaseRepo<NewModel> { }
    class Test
    {
        public void TestMethod()
        {
            BaseRepo<BaseModel> t1 = new BaseRepo<BaseModel>();
            BaseRepo<NewModel> t2 = new NewRepo();
            ICovariant<BaseModel> t3 = new BaseRepo<NewModel>();
            ICovariant<BaseModel> t4 = new NewRepo();
        }
    }
