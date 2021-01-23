    public /* delegate */ class PerformCalculation : MulticastDelegate {
        public PerformCalculation(object target, IntPtr method) {}
        public virtual void Invoke(int x, int y) {}
        public virtual IAsyncResult BeginInvoke(int x, int y, AsyncCallback callback, object state) {}
        public virtual void EndInvoke(IAsyncResult result) {}
    }
