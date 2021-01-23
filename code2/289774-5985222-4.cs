    public class FooController : Controller
    {
        IMessagesProvider _messages;
        public FooController(IMessagesProvider messages)
        {
            // Your DI container will inject the messages provider automatically.
            _messages = messages;
        }
        public ActionResult Index()
        {
            ViewData["messages"] = _messages.GetMessages(Session.SessionId);
            return View();
        }
    }
