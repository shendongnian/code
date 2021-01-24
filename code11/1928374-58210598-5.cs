    [ApiController]
    [Route("[controller]/{name}")]
    [ValidateNameParameter] // <-- execute this for all actions in the controller
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        public string Sample([StringLength(10)][FromRoute]string name)
        {
        }
    
        [HttpGet]
        [Route("defaults")]
        public string GetDefaults([StringLength(10)][FromRoute]string name)
        {
        }
    
        [HttpGet]
        [Route("objects/{id}")]
        // [ValidateNameParameter] // <-- execute for this specific action
        public string Sample([StringLength(10)][FromRoute]string name, [FromRoute]string id)
        {
        }
    }
