    public ServiceDependencies{
         public ILogger Logger{get; private set;}
         public ServiceDependencies(ILogger logger){
              this.Logger = logger;
         }
    }
    
    public abstract class BaseService{
         public ILogger Logger{get; private set;}
    
         public BaseService(ServiceDependencies dependencies){
              this.Logger = dependencies.Logger; //don't expose 'dependencies'
         }
    }
    
    
    public class DerivedService(ServiceDependencies dependencies,
                                  ISomeOtherDependencyOnlyUsedByThisService                       additionalDependency) 
     : base(dependencies){
    //set local dependencies here.
    }
