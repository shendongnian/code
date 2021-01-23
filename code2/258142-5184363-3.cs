    public class MyController {
    
        public ActionResult Index() { }
    
        [Authorize(Roles="Administrator")]
        public ActionResult Admin() { }
  
    }
