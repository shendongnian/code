    public class ForumsController : ControllerBase
    {
        private readonly IMyComponent _myComponent;
        public ForumsController(IMyComponent myComponent)
        { 
            _myComponent = myComponent;
        }
        // GET api/forums
        [HttpGet]
        public ActionResult<string> Get()
        {
            var data = _myComponent.GetDataFromSession();//call method and return "value"
            return data;
        }
