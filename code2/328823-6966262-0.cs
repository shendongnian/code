    public interface IRequestHandler
        {
            bool CanHandle(Request req);
    
            void Handle(Request req);
        }
    
        public class LargeRequestHandler : IRequestHandler
        {
            public bool CanHandle(Request req)
            {
                return (req.Type == RequestType.SomeVal && req.id > 1000);
            }
    
            public void Handle(Request req)
            {
                processors.Add(new ProcessLargeRequest(request));
            }
        }
    
        public class SmallRequestHandler : IRequestHandler
        {
            public bool CanHandle(Request req)
            {
                return (req.Type == RequestType.SomeVal && req.id < 1000);
            }
    
            public void Handle(Request req)
            {
                processors.Add(new SmallLargeRequest(request));
            }
        }
