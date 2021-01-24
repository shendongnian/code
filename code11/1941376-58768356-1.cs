    public class SomeApi1Controller : ControllerBase
    {
        private readonly IApi2Service _api2Service;
        public SomeApi1Controller(IApi2Service api2Service)
        {
            _api2Service = api2Service;
        }
        public async Task<IActionResult> SomeAction()
        {
            var foo = await _api2Service.GetFooByIdAsync(1);
        }
    }
