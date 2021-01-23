    public class RootController : Controller
    {
    
        [HttpGet]
        public ActionResult Default(string pathName)
        {
            // No pathName? 
    
            if (String.IsNullOrWhiteSpace(pathName)) {
                return this.View("~/Views/Root/home.aspx")
            }
    
            // Check to see if there's a view for the pathName
    
            var viewPath = String.Format("~/Views/Root/{0}.aspx", pathName);
    
            if (File.Exists(Server.MapPath(viewPath))) {
                return this.View(viewPath);
            }
            // Not found
    
            this.Response.StatusCode = System.Net.HttpStatusCode.NotFound;
            return this.View("~/Views/404.aspx");
        }
    
    }
