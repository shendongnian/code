    static void Main(string[] args)
    {
        TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
        // ...
    }
    private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
    {
        // Log the e.Exception, which is an AggregateException
        WriteToTextFile("Exception from task:" + e.Exception);
    }
