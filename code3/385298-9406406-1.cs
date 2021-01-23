    public class CoreServicesDependencyGroup : ICoreServicesDependencyGroup
    {
       private readonly IAspNetMvcLoggingService _loggingService;
       private readonly IUnitOfWork _unitOfWork;
    
       public CoreServicesDependencyGroup(
          IAspNetMvcLoggingService loggingService, 
          IUnitOfWork unitOfWork)
       {
          Condition.Requires(loggingService).IsNotNull();
          Condition.Requires(unitOfWork).IsNotNull();
          _loggingService = loggingService;
          _unitOfWork = unitOfWork;
       }
    
       public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }
       public IAspNetMvcLoggingService LoggingService { get { return _loggingService; } }
    }
