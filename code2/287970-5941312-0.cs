    public class LCLMulticastEvent<TEventArgs> where TEventArgs : EventArgs
    {
        private event EventHandler<TEventArgs> internalEvent;
        private object lockObject = new object();
        public event EventHandler<TEventArgs> OnEvent
        { 
            add { internalEvent += value; }
            remove { internalEvent -= value; }
        } 
    }
