    public class DataController : Controller
    {
        //note: HttpGet attribute is only one of many ways to template the route
        [HttpGet("/Data/FilterOptions")]
        public IActionResult GetFilterOptions(string paramOne, string paramTwo) { }
    }
