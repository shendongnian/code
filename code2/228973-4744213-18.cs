    public class DisposableWebRequest : WebRequest, IDisposable
    {
        private static int _Counter = 0;
        private readonly WebRequest _request;
        private readonly int _index;
        private volatile bool _disposed = false;
        public DisposableWebRequest (string url)
        {
            this._request = WebRequest.Create(url);
            this._index = ++DisposableWebRequest._Counter;
        }
        public override IAsyncResult BeginGetResponse(AsyncCallback callback, object state)
        {
            return this._request.BeginGetResponse(callback, state);
        }
        public override WebResponse EndGetResponse(IAsyncResult asyncResult)
        {
            Trace.WriteLine(string.Format("EndGetResponse index {0} in thread {1}", this._index, Thread.CurrentThread.ManagedThreadId));
            Trace.Flush();
            if (!this._disposed)
            {
                return this._request.EndGetResponse(asyncResult);
            }
            else
            {
                return null;
            }
        }
        public override WebResponse GetResponse()
        {
            return this._request.GetResponse();
        }
        public override void Abort()
        {
            this._request.Abort();
        }
        public void Dispose()
        {
            if(!this._disposed)
            {
                this._disposed = true;
                Trace.WriteLine(string.Format("Disposed index {0} in thread {1}", this._index, Thread.CurrentThread.ManagedThreadId ));
                Trace.Flush();
                this.Abort();
            }
        }
    }
