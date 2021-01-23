    public class TestInvoker
    {
        public IAsyncResult MockResult { get; set; }
        public override void InvokeMethod(Action method, Action callback)
        {
             method();
             callback(MockResult);
        }
    }
