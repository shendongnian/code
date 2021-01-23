    public class ExternalResourceHandler
    {
        private volatile boolean _running;
        private readonly ExternalResource _resource;
        private readonly BlockingQueue<Request> _requestQueue;
        
        public ExternalResourceHandler( BlockingQueue<Request> requestQueue)
        {
            _requestQueue =  requestQueue;
            _running = false;
        }
        
        public void QueueRequest(Request request)
        { 
            _requestQueue.Enqueue(request);
        }
        
        public void Run()
        {
            _running = true;
            while(_running)
            {
                Request request = null;
                if(_requestQueue.TryDequeue(ref request) && request!=null)
                {
                    _resource.Execute(request);
                }
            }
        }
        
        // methods to stop the handler (i.e. set the _running flag to false)
    }
