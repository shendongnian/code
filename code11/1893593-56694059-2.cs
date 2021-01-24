    [Route("/")]
    [ApiController]
    public class MyController : ControllerBase
    {
        [HttpGet("{instance}/info")]
        public JsonResult Info(string instance, [FromQuery] InfoCommand model)
        {
            var result = new JsonResult(model);
            return result;
        }
    }
    public class InfoCommand
    {
        public InfoCommand()
        {}
        public string Param1 { get; set; }
        public string Param2 { get; set; }
    }
