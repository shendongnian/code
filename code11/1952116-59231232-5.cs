    public class MyController: Controller {
        private readonly IHelper helper;
    
        public MyController(IHelper helper) {
            this.helper = helper;
        }    
    
        [HttpGet]
        public JsonResult GetSomething() {
            //...use helper 
    
            return Ok("");
        }
    
        //...
    }
