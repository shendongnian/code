    public class CommonFileSaver : IFileSaver
    {
       public CommonFileSaver(ILogFactory logFactory)
       {
          _log = logFactory.GetLogger();
       } 
    
       private readonly ILog _log;
    
       .....
    }
