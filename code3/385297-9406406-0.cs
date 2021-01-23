    public interface ICoreServicesDependencyGroup
    {
       IUnitOfWork UnitOfWork { get; }
       IAspNetMvcLoggingService LoggingService { get; }
    }
