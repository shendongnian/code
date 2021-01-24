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
            // but you do call the delegate with the required parameters
            this.method(1, 2);
        }
    }
    // Then call it like this
    var delegateInvoker = new DelegateInvoker(Test);
    delegateInvoker.InvokeDelegate();
