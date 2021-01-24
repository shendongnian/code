    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        [HttpGet("{id}", Name = "HelloDetails")]
        public IActionResult GetDetail(int id)
        {
            var result = new MyItem() {
                Id=id,
                ItemName="sherry"
            }; 
            
            return new JsonResult(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MyItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            
            return CreatedAtRoute("HelloDetails", new { id = item.Id }, item);
        }
