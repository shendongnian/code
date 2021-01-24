    [Authorize(PolicyConstants.Admin)]
    public class TestController
    {
        // here also you can use specific policy and for controller, you can use other policy. It will match Action Level policy first and then match controller policy.
        public IActionResult Index()
        {
        }
    }
