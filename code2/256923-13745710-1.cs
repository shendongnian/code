    public class JsonController : Controller
    {
        public ActionResult Data()
        {
            dynamic expando = new ExpandoObject();
            expando.name = "John Smith";
            expando.age = 30;
    
            var json = JsonConvert.SerializeObject(expando);
    
            return Content(json, "application/json");
        }
    }
