     public class Service
        {
            private BusinessLogic businessLayer = new BusinessLogic();
            public IAsyncResult BeginOperation(AsyncCallback callback, object userState)
            {
                return businessLayer.ComputeDataAsync(callback, userState);
            }
    
            public string EndOperation(IAsyncResult result)
            {
                var myResult = (MyState<string>)result;
                return myResult.Result;
            }
        }
     public class MyState<T> : IAsyncResult
        {
            public MyState()
            {
            }
            public object AsyncState
            {
                get;
                set;
            }
            public WaitHandle AsyncWaitHandle
            {
                get;
                set;
            }
            public bool CompletedSynchronously
            {
                get { return true; }
            }
    
            public bool IsCompleted
            {
                get;
                set;
            }
    
            public AsyncCallback AsyncCallback
            {
                get;
                set;
            }
    
            public T Result { get; set; }
        }
    
        public class BusinessLogic
        {
            public IAsyncResult ComputeDataAsync(AsyncCallback callback, object state)
            {
                MyState<string> myState = new MyState<string>() { AsyncCallback = callback, AsyncState = state };
                DataAccessLayer dal = new DataAccessLayer();
                var task = dal.GetData();
                task.ContinueWith((t) =>
                {
                    myState.Result = task.Result;
                    myState.IsCompleted = true;
                    myState.AsyncCallback(myState);
                });
                return myState;
            }
        }
    
        public class DataAccessLayer
        {
            public Task<string> GetData()
            {
                return Task.Factory.StartNew<string>(() =>
                {
                    var random = new Random().Next(1000);
                    Thread.Sleep(random);
                    return string.Format("i worked hard for {0} ms", random);
                });
            }
        }
