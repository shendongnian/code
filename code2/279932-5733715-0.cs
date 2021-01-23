    public interface IMyManager<TModel>
        where T : ILibModel
    {
        void SetModel(TModel model);
    }
    
    public class MyManager : IMyManager<MyModel>
    {
        void SetModel(MyModel model)
        {
    
        }
    }
