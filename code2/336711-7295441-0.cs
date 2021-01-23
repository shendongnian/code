    interface ILibrary
    {
        IAsyncResult BeginAction(string name, AsyncCallback callback, object state);
        int EndAction(IAsyncResult asyncResult, out object state);
    }
    class Manager
    {
        private ILibrary library;
        class AsyncCallInfo : IAsyncResult
        {
            public int PendingOps;
            public AsyncCallback Callback { get; set; }
            public object AsyncState { get; set; }
            public WaitHandle AsyncWaitHandle
            {
                // Implement this if needed
                get { throw new NotImplementedException(); }
            }
            public bool CompletedSynchronously
            {
                get { return false; }
            }
            public bool IsCompleted
            {
                get { return PendingOps == 0; }
            }
        }
        public IAsyncResult BeginMultipleActions(IEnumerable<string> names,
                                                 AsyncCallback callback, object state)
        {
            var callInfo = new AsyncCallInfo {
                Callback = callback,
                AsyncState = state
            };
            callInfo.PendingOps = names.Count();
            foreach (string name in names)
            {
                library.BeginAction(name, ar => OnSingleActionCompleted(ar, callInfo), null);
            }
            return callInfo;
        }
        public int EndMultipleActions(IAsyncResult asyncResult, out object state)
        {
            // do your stuff
            state = asyncResult.AsyncState;
            return 0;
        }
        private void OnSingleActionCompleted(IAsyncResult asyncResult, AsyncCallInfo callInfo)
        {
            //???
            Interlocked.Decrement(ref callInfo.PendingOps);
            if (callInfo.PendingOps == 0)
            {
                callInfo.Callback(callInfo);
            }
        }
    }
