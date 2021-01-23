    public class Foo
    {
        private readonly IRequestHandler _handler;
        public Foo(IRequestHandler handler)
        {
            _handler = handler;
        }
        public string DoSomeWork(Request request)
        {
            return _handler.Handle(request);
        }
    }
