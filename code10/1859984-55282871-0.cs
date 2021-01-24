    public class MyService : IMyService
    {
      public MyService(IDepedencySolver ds, IRepository rep = null, IMapper mapper = null)
      { 
         _rep = rep ?? ds.GetService<IDependencySolver>();
         _mapper = mapper ?? ds.GetService<IMapper>();
    
 
        ...
       }
    }
