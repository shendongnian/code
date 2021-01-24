    namespace TodoApi.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class TodoController : Controller
       {
          [HttpGet("{id}")]
    public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
    {
    //do here
        }
    }
    }
