    public interface IService<TModel>
    {
      TModel Get(string id);
    }
    public class MyService : IService<MyModel>
    {
      public MyModel Get(string id)
      {
        // Work
      }
    }
    var service = new MyService();
    var model = service.Get("something");
