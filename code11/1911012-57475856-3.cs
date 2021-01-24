    class DelegateInvoker
    {
        private DelegateWithParameters method;
        public DelegateInvoker(DelegateWithParameters method)
        {
            this.method = method ?? throw new ArgumentNullException(nameof(method));
        }
        
        // Note this signature is parameterless
        public void InvokeDelegate()
        {
            this.method(1, 2);
        }
    }
    // Then call it like this
    var delegateInvoker = new DelegateInvoker(Test);
    delegateInvoker.InvokeDelegate();
