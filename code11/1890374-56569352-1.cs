    public class HomeController : Controller
    {
        private readonly MyOptions[] myOptions;
        public HomeController(IOptionsMonitor<Options> myOptions)
        {
            this.myOptions = myOptions.CurrentValue.MyArray;
        }
    }
