    // This is the class that implements the async operations that the caller will see
    internal class MyClass
    {
        public MyClass() { /* . . . */ }
    
        public IAsyncResult BeginMyOperation(Uri requestUri, AsyncCallback callback, object state)
        {
            return new MyOperationAsyncResult(this, requestUri, callback, state);
        }
    
        public WebResponse EndMyOperation(IAsyncResult result)
        {
            MyOperationAsyncResult asyncResult = (MyOperationAsyncResult)result;
            return asyncResult.EndInvoke();
        }
    
        private sealed class MyOperationAsyncResult : AsyncResult<WebResponse>
        {
            private readonly MyClass parent;
            private readonly HttpWebRequest webRequest;
            private bool everCompletedAsync;
    
            public MyOperationAsyncResult(MyClass parent, Uri requestUri, AsyncCallback callback, object state)
                : base(callback, state)
            {
                // Occasionally it is necessary to access the outer class instance from this inner
                // async result class.  This also ensures that the async result instance is rooted
                // to the parent and doesn't get garbage collected unexpectedly.
                this.parent = parent;
    
                // Start first async operation here
                this.webRequest = WebRequest.Create(requestUri);
                this.webRequest.Method = "POST";
                this.webRequest.BeginGetRequestStream(this.OnGetRequestStreamComplete, null);
            }
            private void SetCompletionStatus(IAsyncResult result)
            {
                // Check to see if we did not complete sync. If any async operation in
                // the chain completed asynchronously, it means we had to do a thread switch
                // and the callback is being invoked outside the starting thread.
                if (!result.CompletedSynchronously)
                {
                    this.everCompletedAsync = true;
                }
            }
    
            private void OnGetRequestStreamComplete(IAsyncResult result)
            {
                this.SetCompletionStatus(result);
                Stream requestStream = null;
                try
                {
                    stream = this.webRequest.EndGetRequestStream(result);
                }
                catch (WebException e)
                {
                    // Cannot let exception bubble up here as we are on a callback thread;
                    // in this case, complete the entire async result with an exception so
                    // that the caller gets it back when they call EndXxx.
                    this.SetAsCompleted(e, !this.everCompletedAsync);
                }
                if (requestStream != null)
                {
                    this.WriteToRequestStream();
                    this.StartGetResponse();
                }
            }
    
            private void WriteToRequestStream(Stream requestStream) { /* omitted */ }
    
            private void StartGetResponse()
            {
                try
                {
                    this.webRequest.BeginGetResponse(this.OnGetResponseComplete, null);
                }
                catch (WebException e)
                {
                    // As above, we cannot let this exception bubble up
                    this.SetAsCompleted(e, !this.everCompletedAsync);
                }
            }
    
            private void OnGetResponseComplete(IAsyncResult result)
            {
                this.SetCompletionStatus(result);
                try
                {
                    WebResponse response = this.webRequest.EndGetResponse(result);
    
                    // At this point, we can complete the whole operation which
                    // will invoke the callback passed in at the very beginning
                    // in the constructor.
                    this.SetAsCompleted(response, !this.everCompletedAsync);
                }
                catch (WebException e)
                {
                    // As above, we cannot let this exception bubble up
                    this.SetAsCompleted(e, !this.everCompletedAsync);
                }
            }
        }
    }
