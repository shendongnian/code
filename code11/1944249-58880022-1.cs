DataReceivedArgs args = new DataReceivedArgs();
ManualResetEvent completionEvent = new ManualResetEvent(false);
byte[] ioBuffer = new byte[1024];
NativeOverlapped nol = new NativeOverlapped
{
    EventHandle = completionEvent.SafeWaitHandle.DangerousGetHandle()
};
try
{
    for (; ; )
    {
        completionEvent.Reset();
        uint bytesRead = 0;
        GCHandle pin = GCHandle.Alloc(ioBuffer, GCHandleType.Pinned);
        if (!ReadFile(_handle.DangerousGetHandle(), ioBuffer, ioBuffer.Length, out int dontCare, ref nol))
        {
            int lastError = Marshal.GetLastWin32Error();
            if (lastError != OperationInProgress)
            {
                if (lastError != ErrorInvalidHandle)
                {
                    Win32Exception ex = new Win32Exception(lastError);
                    MessageBox.Show("ReadFile failed. Error: " + ex.Message);
                }
                break;
            }
            completionEvent.WaitOne();
            if (!GetOverlappedResult(_handle.DangerousGetHandle(), ref nol, out bytesRead, true))
            {
                bytesRead = 0;
            }
        }
        else
        {
            throw new IOException();
        }
        if (bytesRead > 0)
        {
            byte[] sizedBuffer = new byte[bytesRead];
            Array.Copy(ioBuffer, 0, sizedBuffer, 0, bytesRead);
            args.Data = sizedBuffer;
            DataReceived?.Invoke(this, args);
        }
        pin.Free();
    }
}
catch (ThreadAbortException)
{
}
completionEvent.Dispose();
