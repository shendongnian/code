    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Question>> Get()
        {
            var questions = new List<Question>(2);
            questions.Add(new Question()
            {
                property = "test",
                required = true,
                type = "string",
                label = "Test Id",
                constraints = new Constraints() { maxSize = "10", minSize = "9" }
            });
    
            questions.Add(new Question()
            {
                property = "Email",
                required = true,
                type = "string",
                label = "Email Address",
                constraints = new Constraints() { maxSize = "128", minSize = "1" }
            });
    
            return Ok(new { questions });
        }
    }
