private static class NativeMethods
{
    [DllImport("kernel32.dll")]
    public static extern bool AllocConsole();
    [DllImport("kernel32.dll")]
    public static extern bool FreeConsole();
    [DllImport("kernel32.dll")]
    public static extern bool AttachConsole(int pid);
}
public static void Main(string[] args)
{
    int ret = 0;
    if (args.Length == 0)
    {
        RunService();
    }
    else
    {
        if (!NativeMethods.AttachConsole(-1))
        {
            NativeMethods.AllocConsole();
        }
        RunConsole();
        NativeMethods.FreeConsole();
    }
}
private static void RunService()
{
    // ...
    ServiceBase.Run(...)
    // ...
}
private static void RunConsole()
{
    var closeEvent = new ManualResetEvent(false);
    Console.CancelKeyPress += (o, e) => closeEvent.Set();
    new NotificationService().OnStart();
    closeEvent.WaitOne();
}
------
Alternatively, it's not uncommon to have a separate Console project which references your Service project, which is just used for testing.
--------
Although these solutions are neater than a timer with a long sleep, they will have the same effect of blocking the main thread (which is somewhat unavoidable). I think the problem with your notification service is a separate issue.
