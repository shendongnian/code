    public class InvalidWaitHandle : WaitHandle
    {
        public IntPtr Handle
        {
            get { return InvalidHandle; }
            set { throw new InvalidOperationException(); }
        }
    }
