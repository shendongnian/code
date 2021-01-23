    public class MyWaitHandle: WaitHandle
    {
        internal AutoResetEvent InternalEvent { get; private set; }
        internal MyWaitHandle(AutoResetEvent event)
        {
            InternalEvent = event;
        }
        public override bool WaitOne(int32 timeout)
        {
            return InternalEvent.WaitOne();
        }
    }
