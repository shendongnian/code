    public abstract class ApplicationController : Controller
    {
        protected Logger _logger;
        protected virtual Logger Logger(string className)
        {
           return LogManager.GetLogger(className);
        }
    }
    
    
    public class PropertyController : ApplicationController
    {
        private readonly DatatapeService _datatapeService;
        private readonly PropertyService _propertyService;
        protected override Logger Logger()
        {
            return base.Logger("PropertyController ");
        }
    }
