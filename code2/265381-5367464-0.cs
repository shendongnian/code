    private static EventWaitHandle ev;
    //...
    [MTAThread]
    public static void Main()
    {
        //...
        ev = new EventWaitHandle(false, EventResetMode.ManualReset);
        //...
        ev.WaitOne(); //Stop execution
        //...
    }
    
    //Another thread function.
    public static void ThreadProc()
    {
        ev.Set(); //Continue execution of Main
    }
