     public class Startup
     {
        ...
        public void ConfigureServices(IServiceCollection services)
        {      
          services.AddLogging();
          services.AddTransient<ClassX>();
          services.AddTransient<ClassY>();
          services.AddTransient<ClassZ>();
          services.AddTransient<ClassD>();
          ...
        }
    }
    public class ControllerB : ControllerBase
    {
        private readonly ClassD classD;
        private readonly ILogger logger;
        public ValuesController(ClassD classD, ILogger<ControllerB> logger)
        {
            this.classD = classD;
            this.logger = logger;
        }
        ...
    }
    public class ClassD
    {
       private readonly ClassZ classZ;
    
       public ClassD(ClassZ classZ)
       {
           this.classZ = classZ;
       }
    } //Do the same thing for ClassZ and ClassY
    
    public class ClassX
    {
       private readonly ILogger logger;
    
       public ClassX(ILogger<ClassX> logger)
       {
           this.logger = logger;
       }
    }
