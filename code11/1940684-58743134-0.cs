     [Route("api/[controller]/{id}")]
        [ApiController]
        public class ValuesController : ControllerBase
        {
            // GET api/values/5
            [HttpGet()]
            public ActionResult<string> Get(string id)
            {
    
                if (int.TryParse(id, out int result))
                {
                    return Ok(id);
    
                }
                else if (DateTime.TryParse(id, out DateTime result1))
                {
                    return Ok(id);
                }
                else
                    return Ok("Failed");
            }
        }
