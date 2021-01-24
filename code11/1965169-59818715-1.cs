        public class MyInt{
            public int Value { get; set; }
            public bool IsNull { get; set; }
        }
    
        [ApiController]
        [Route("example")]
        public class MyExampleController : ControllerBase
        {
            [HttpPost("{id}/value")]
            public IActionResult Post(string id, [FromBody]MyInt value)
            {
                if(value.IsNull){
    
                }
                else{
    
                }
                return Ok();
            }
        }
