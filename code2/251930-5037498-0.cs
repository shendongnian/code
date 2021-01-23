        public class MyAsyncResult : IAsyncResult
        {
            bool _result;
    
            public MyAsyncResult(bool result)
            {
                _result = result;
            }
    
            public bool IsCompleted
            {
                get { return true; }
            }
    
            public WaitHandle AsyncWaitHandle
            {
                get { throw new NotImplementedException(); }
            }
    
            public object AsyncState
            {
                get { return _result; }
            }
    
            public bool CompletedSynchronously
            {
                get { return true; }
            }
        }
