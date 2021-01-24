        public class HomeController : Controller
       {
        
            private readonly RfidClass _rfidClass;
        
            public HomeController(IOptionsMonitor<ConfigurationModel> options)
            {
                _rFidClass= options.CurrentValue;
            }
        
            public IActionResult Index()
            {
                var rfidAddress = _rfidClass.rfidAddress;
                var baudRate = rfidClass.BaudRate;
               // do stuff.
                return View();
            }
        }
