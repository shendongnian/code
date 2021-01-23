     public static class NativeMethods
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern UInt32 WaitForSingleObject(SafeWaitHandle hHandle, UInt32 dwMilliseconds);
    }
    public static class WaitHandleExtensions
    {
        const UInt32 INFINITE = 0xFFFFFFFF;
        const UInt32 WAIT_ABANDONED = 0x00000080;
        const UInt32 WAIT_OBJECT_0 = 0x00000000;
        const UInt32 WAIT_TIMEOUT = 0x00000102;
        const UInt32 WAIT_FAILED = INFINITE;
        /// <summary>
        /// Waits preventing an I/O completion routine or an APC for execution by the waiting thread (unlike default `alertable`  .NET wait). E.g. prevents STA message pump in background. 
        /// </summary>
        /// <returns></returns>
        /// <seealso cref="http://stackoverflow.com/questions/8431221/why-did-entering-a-lock-on-a-ui-thread-trigger-an-onpaint-event">
        /// Why did entering a lock on a UI thread trigger an OnPaint event?
        /// </seealso>
        public static bool WaitOneNonAlertable(this WaitHandle current, int millisecondsTimeout)
        {
            if (millisecondsTimeout < -1)
                throw new ArgumentOutOfRangeException("millisecondsTimeout", millisecondsTimeout, "Bad wait timeout");
            uint ret = NativeMethods.WaitForSingleObject(current.SafeWaitHandle, (UInt32)millisecondsTimeout);
            switch (ret)
            {
                case WAIT_OBJECT_0:
                    return true;
                case WAIT_TIMEOUT:
                    return false;
                case WAIT_ABANDONED:
                    throw new AbandonedMutexException();
                case WAIT_FAILED:
                    throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
                default:
                    return false;
            }
        }
    }
