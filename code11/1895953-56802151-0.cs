    [Route("[controller]/[action]")]
    public class QuestionController : Controller {
     [HttpGet("{id}/{title}")]
     public async Task<IActionResult> Index(int id, string title) {
    
     }
    
    }
