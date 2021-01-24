    public class HomeController : BaseController
    {
        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            
            var path = exceptionPathFeature.Path;
    
            if(path.Contains("/Administration/"))
                return View("AdministrationErrorPage");
    
            if(path.Contains("/Production/"))
                return View("ProductionErrorPage");
    
            return View("GenericErrorPage");
        }
    }
