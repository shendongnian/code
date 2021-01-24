    public class HomeController : Controller
    {
       public HomeController(AppSettings settings)
       {
          this.Settings = settings;
       }
    
       private AppSettings Settings { get; }
    
       public IActionResult Index()
       {
          MyClass.DosomeThing(this.Settings);
       }
    }
    
    internal static MyClass
    {
        internal static void DosomeThing(AppSettings settings)
        {
            // acquire my service
            // use it to retrieve some value
            // continue with my logic
    
        }
    }
