    public class FooController : ControllerBase
    {
        public FooController(IFormsCookieName formsCookieName)
        {
            // receives a FormsCookieName instance that can safely use it's non-static properties
        }
    }
