        [Route("api/[controller]")]
        [ApiController]
        public class ValuesController : ControllerBase
        {
            [HttpPut("[Action]/{id}")]
            public async Task<ActionResult> Link(int id, IFormFile file)
            {
                return Ok(id);
            }
        }
