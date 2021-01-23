    public class RequestChain
        {
            IRequestHandler[] handlers;
    
            public RequestChain()
            {
                handlers = new[] { new LargeRequestHandler(), new SmallRequestHandler() };
            }
    
            public void ProcessRequest(Request req)
            {
                foreach (var handler in handlers)
                {
                    if (handler.CanHandle(req))
                    {
                        handler.Handle(req);
                    }
                }
            }
        }
