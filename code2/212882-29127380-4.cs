    EventWaitHandle handle = new EventWaitHandle(
        false,                                /* Create handle in unsignaled state */
        EventResetMode.ManualReset,           /* Ignored.  This instance doesn't reset. */
        InterprocessProtocol.EventHandleName  /* String defined in a shared assembly. */
    );
    ProcessStartInfo startInfo = new ProcessStartInfo("Process2.exe");
    using (Process proc = Process.Start(startInfo))
    {
        //Wait for process 2 to initialize.
        handle.WaitOne();
        //TODO
    }
