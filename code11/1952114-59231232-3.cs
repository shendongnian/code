    public class MyController: Controller {
        private readonly Helper helper;
    
        public MyController(Helper helper) {
            this.helper = helper;
        }    
    
        [HttpGet]
        public JsonResult GetSomething() {
            //...use helper 
    
            return Ok("");
        }
    
        //...
    }
