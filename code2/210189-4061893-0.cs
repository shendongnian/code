    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Threading;
    namespace Willys
    {
    class Program
    {
    [DllImport("kernel32.dll")]
    public static extern IntPtr CreateWaitableTimer(IntPtr
    lpTimerAttributes,
    bool bManualReset, string lpTimerName);
    
    [DllImport("kernel32.dll")]
    public static extern bool SetWaitableTimer(IntPtr hTimer, [In] ref long
    pDueTime, int lPeriod, IntPtr pfnCompletionRoutine, IntPtr
    lpArgToCompletionRoutine, bool fResume);
    
    [DllImport("kernel32", SetLastError = true, ExactSpelling = true)]
    public static extern Int32 WaitForSingleObject(IntPtr handle, uint
    milliseconds);
    
    static void Main()
    {
    SetWaitForWakeUpTime();
    }
    
    static IntPtr handle;
    static void SetWaitForWakeUpTime()
    {
    long duetime = -300000000; // negative value, so a RELATIVE
    due time
    handle = CreateWaitableTimer(IntPtr.Zero, true,
    "MyWaitabletimer");
    SetWaitableTimer(handle, ref duetime, 0, IntPtr.Zero,
    IntPtr.Zero, true);
    long duetime = -300000000;
    Console.WriteLine("{0:x}",duetime);
    handle = CreateWaitableTimer(IntPtr.Zero, true,
    "MyWaitabletimer");
    SetWaitableTimer(handle, ref duetime, 0, IntPtr.Zero,
    IntPtr.Zero, true);
    uint INFINITE = 0xFFFFFFFF;
    int ret = WaitForSingleObject(handle, INFINITE);
    MessageBox.Show("Wake up call");
    }
    
    }
