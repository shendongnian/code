    [Route("Question")]
    public class QuestionController : Controller 
    {
     [HttpGet("{id}/{title}")]
     public async Task<IActionResult> Index(int id, string title) 
     {
      //Your Code
     }
    }
