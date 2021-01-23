    public class ModelFactory<TModel>
    {
      IService<TModel> _service;
    
      public ModelFactory(IService<TModel> service)
      {
        _service = service;
      }
      
      public TModel Get(string code)
      {
        return _service.Get(code);
      }
      
    }
