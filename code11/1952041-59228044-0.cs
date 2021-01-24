    [Route("api/[controller]")]
    public class TestController: Controller {
        //GET api/test/edit?id=1&id2=4
        [HttpGet("Edit")]
        [AllowAnonymous]
        public ActionResult Edit(int id, int id2) {
            //...
            return Ok(3);
        }
    
        //GET api/test/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }
    }
