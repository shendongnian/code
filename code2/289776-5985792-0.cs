    public class FooController : Controller
    {
        Messages _messages;
        // MVC will call this ctor
        public FooController() : this(new Messages())
        {
        }
        // call this ctor in your unit-tests with a mock object, testing subclass, etc.
        public FooController(Messages messages)
        {
            _messages = messages;
        }    
    }
