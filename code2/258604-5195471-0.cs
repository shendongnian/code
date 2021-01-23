    public class WaitableTimer: IDisposable
    {
        [DllImport("kernel32.dll")]
        private static extern SafeWaitHandle CreateWaitableTimer(IntPtr lpTimerAttributes, bool bManualReset, string lpTimerName);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWaitableTimer(SafeWaitHandle hTimer, [In] ref long pDueTime, int lPeriod, IntPtr pfnCompletionRoutine, IntPtr lpArgToCompletionRoutine, bool fResume);
        [DllImport("kernel32.dll")]
        private static extern bool CancelWaitableTimer(SafeWaitHandle hTimer);
        private SafeWaitHandle _handle;
        private EventWaitHandle _waitHandle;
        private readonly AutoResetEvent _cancelEvent = new AutoResetEvent(false);
        
        public WaitableTimer()
        {
            _handle = CreateWaitableTimer(IntPtr.Zero, true, "WaitableTimer_" + Guid.NewGuid());
            _waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
            _waitHandle.SafeWaitHandle = _handle;
        }
        public void InterruptWait()
        {
            _cancelEvent.Set();
        }
        
        public bool WaitUntil(DateTime eventTime)
        {
            long duetime = eventTime.ToFileTime();            
            if (SetWaitableTimer(_handle, ref duetime, 0, IntPtr.Zero, IntPtr.Zero, true))
            {
                return WaitHandle.WaitAny(new[] { _waitHandle, _cancelEvent }) == 0;
            }
            else
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
        public void Dispose()
        {
            InterruptWait();
            _handle.Dispose();
        }
    }
