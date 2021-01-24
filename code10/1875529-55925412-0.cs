    public class Model 
    { 
        [Required]
        public DateTime? PublishedAt { get; set; }       
    }
    [ApiController]
    public class ValuesController : ControllerBase
    {
       public async Task<IActionResult> Create([FromBody]Model model) 
       {
       }
    }
