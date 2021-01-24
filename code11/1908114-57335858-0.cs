    public class TestController : ControllerBase
    {
        private readonly BALServices _balService;
        public TestController(BALServices balService)
        {
            _balService = balService;
        }
    }
