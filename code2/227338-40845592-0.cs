    public class MyOperationInvoker : IOperationInvoker
    {
        IOperationInvoker originalInvoker;
        public MyOperationInvoker(IOperationInvoker originalInvoker)
        {
            this.originalInvoker = originalInvoker;
        }
        public bool IsSynchronous { get { return originalInvoker.IsSynchronous; } }
        public object[] AllocateInputs() { return originalInvoker.AllocateInputs(); }
        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            //Do stuff before call
            var res = this.originalInvoker.Invoke(instance, inputs, out outputs);
            //stuff after call
            return res;
        }
        public IAsyncResult InvokeBegin(object instance, object[] inputs,
                    AsyncCallback callback, object state)
        {
            //Do stuff before async call
            var res = this.originalInvoker.InvokeBegin(instance, inputs, callback, state);
            return res;
        }
        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            var res = this.InvokeEnd(instance, out outputs, result);
            //Do stuff after async call
            return res;
        }
    }
