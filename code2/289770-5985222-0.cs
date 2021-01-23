    public class FooController
    {
        IMessagesProvider _messages;
        public FooController(IMessagesProvider messages)
        {
            // Your DI container will inject the messages provider automatically.
            _messages = messages;
        }
        public ActionResult Index()
        {
            ViewData["messages"] = _messages.GetMessages(SessionId);
            return View();
        }
    }
