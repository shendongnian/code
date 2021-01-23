    public delegate IResponse DispatchMessageWithTimeoutDelegate(IRequest request, int timeout = MessageDispatcher.DefaultTimeoutMs);
    [Serializable]
    public sealed class MessageDispatcher
    {
        public const int DefaultTimeoutMs = 500;
    
        /// <summary>
        /// Public method called on one more many threads to send a request with a timeout
        /// </summary>
        public IResponse SendRequest(IRequest request, int timeout)
        {
            var dispatcher = new DispatchMessageWithTimeoutDelegate(SendRequestWithTimeout);
            return DomainInvoker.ExecuteInNewDomain<Response>(dispatcher, request, timeout);
        }
    
        /// <summary>
        /// Worker method invoked by the <see cref="DomainInvoker.ExecuteInNewDomain<>"/> process 
        /// </summary>
        private IResponse SendRequestWithTimeout(IRequest request, int timeout)
        {
            IResponse response = null;
    
            var dispatcher = new DispatchMessageDelegate(DispatchMessage);
    
            //Request Dispatch
            var asyncResult = dispatcher.BeginInvoke(request, null, null);
    
            //Wait for dispatch to complete or short-circuit if it takes too long
            if (!asyncResult.AsyncWaitHandle.WaitOne(timeout, false))
            {
                /* Timeout action */
                response = null;
            }
            else
            {
                /* Invoked call ended within the timeout period */
                response = dispatcher.EndInvoke(asyncResult);
            }
    
            return response;
        }
    
        /// <summary>
        /// Worker method to do the actual dispatch work while being monitored for timeout
        /// </summary>
        private IResponse DispatchMessage(IRequest request)
        {
            /* Do real dispatch work here */
            return new Response();
        }
    }
