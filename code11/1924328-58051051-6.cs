    public class ServicesController : Controller {
        private readonly IDataProvider myData;
        public ServicesController(IDataProvider myData) {
            this.myData = myData;
        }
        public IActionResult Index() {
            return View();
        }
        // service returning json for dropdown options fill for tile calculator
        public IActionResult GetCalcDDOptions() {
            var calcOptions = myData.CalcSelectDDSizeAndTilesPerBoxAll(); 
            return Ok(calcOptions);
        }
    }
