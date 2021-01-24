    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using TestAppWithService.Models;
    
    namespace TestAppWithService.Controllers
    {
        public class ServicesController : Controller
        {
            private readonly IConfiguration configuration;
            public ServicesController(IConfiguration config)
            {
                this.configuration = config;
            }
    
            public IActionResult Index()
            {
                return View();
            }
    
            // service returning json for dropdown options fill for tile calculator
            public IActionResult GetCalcDDOptions()
            {
                var calcOptions = MyData.CalcSelectDDSizeAndTilesPerBoxAll(this.configuration); //note: pass the config to the model
                return new ObjectResult(calcOptions);
            }
        }
    }
