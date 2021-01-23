    public delegate IResponse DispatchMessageDelegate(IRequest request);
    
    class Program
    {
        static int _responsesReceived;
    
        static void Main()
        {
            const int max = 500;
    
            for (int i = 0; i < max; i++)
            {
                SendRequest(new Request());
            }
    
            while (_responsesReceived < max)
            {
                Thread.Sleep(5);
            }
        }
    
        static void SendRequest(IRequest request, int timeout = MessageDispatcher.DefaultTimeoutMs)
        {
            var dispatcher = new DispatchMessageWithTimeoutDelegate(SendRequestWithTimeout);
            dispatcher.BeginInvoke(request, timeout, SendMessageCallback, request);
        }
    
        static IResponse SendRequestWithTimeout(IRequest request, int timeout = MessageDispatcher.DefaultTimeoutMs)
        {
            var dispatcher = new MessageDispatcher();
            return dispatcher.SendRequest(request, timeout);
        }
    
        static void SendMessageCallback(IAsyncResult ar)
        {
            var result = (AsyncResult)ar;
            var caller = (DispatchMessageWithTimeoutDelegate)result.AsyncDelegate;
    
            Response response;
    
            try
            {
                response = (Response)caller.EndInvoke(ar);
            }
            catch (Exception)
            {
                response = null;
            }
    
            Interlocked.Increment(ref _responsesReceived);
        }
    }
