    public class ExampleController : ControllerBase
    {
        private readonly IHubContext<MyHub> _myHubContext;
        public ExampleController(IHubContext<MyHub> myHubContext)
        {
            _myHubContext = myHubContext;
        }
        [HttpPost]
        public async Task<IActionResult> PostMessage(string message)
        {
            await _myHubContext.Clients.All.SendAsync("DoSomething", message);
            return Ok();
        }
    }
