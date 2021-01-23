    //in MyApp.BusinessLogic
    public class MyBusinessObject
    {
       private IMyConfiguration _configuration;
       public MyBusinessObject(IMyConfiguration configuration)
       {
         _configuration = configuration;
       }
       //.. code that uses the configuration to do what's needed
    }
    //in MyApp.Entities (any project that is visible anywhere)
    public interface IMyConfiguration 
    {
       //whatever configurable properties are needed
    }
    //in MyApp.Windows
    public class MyRegistryConfiguration : IMyConfiguration 
    {
      //class that loads settings from the registry
    }
    // somewhere in the code
    IMyConfiguration configuration = new MyRegistryConfiguration ();
    MyBusinessObject business = new MyBusinessObject(configuration);
    // use MyBusinessObject to do businessy things
    
