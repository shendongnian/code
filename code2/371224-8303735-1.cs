    public class Service
        {
            private BusinessLogic businessLayer = new BusinessLogic();
            public IAsyncResult BeginAnyOperation(AsyncCallback callback, object userState)
            {
                return businessLayer.BeginComputeData(callback, userState);
            }
            public string EndAnyOperation(IAsyncResult result)
            {
                return businessLayer.EndComputeDate(result);
            }
        }
    
        public class MyState<T> : IAsyncResult
        {
            public MyState() { }
            public object AsyncState { get; set; }
            public WaitHandle AsyncWaitHandle { get; set; }
            public bool CompletedSynchronously
            {
                get { return true; }
            }
            public bool IsCompleted { get; set; }
            public AsyncCallback AsyncCallback { get; set; }
            public T Result { get; set; }
            public IAsyncResult InnerResult { get; set; }
        }
    
        public class BusinessLogic
        {
            private DataAccessLayer dal = new DataAccessLayer();
            public IAsyncResult BeginComputeData(AsyncCallback callback, object state)
            {
                return dal.BeginGetData(callback, state);
            }
            public string EndComputeDate(IAsyncResult asyncResult)
            {
                return dal.EndGetData(asyncResult);
            }
        }
    
        public class DataAccessLayer
        {
            public IAsyncResult BeginGetData(AsyncCallback callback, object state)
            {
                var conn = new SqlConnection("");
                conn.Open();
                SqlCommand cmd = new SqlCommand("myProc", conn);
                var commandResult = cmd.BeginExecuteReader(callback, state, System.Data.CommandBehavior.CloseConnection);
                return new MyState<string> { AsyncState = cmd, InnerResult = commandResult };
            }
            public string EndGetData(IAsyncResult result)
            {
                var state = (MyState<string>)result;
                var command = (SqlCommand)state.AsyncState;
                var reader = command.EndExecuteReader(state.InnerResult);
                if (reader.Read())
                    return reader.GetString(0);
                return string.Empty;
            }
        }
