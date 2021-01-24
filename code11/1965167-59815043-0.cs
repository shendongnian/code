    [Route("example")]
    public class MyExampleController : ControllerBase {
        [HttpPost("{id}/value")]
        public async Task<IActionResult> Post(string id, [FromBody] int? value) {
    
            if (!ModelState.IsValid) {
        
                //...
        
                return BadRequest(ModelState);
            }
    
            //...
    
            return Ok();
        }
    }
