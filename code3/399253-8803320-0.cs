    TaskScheduler.UnobservedTaskException += (sender, args) =>
    {
        Trace.WriteLine(args.Exception.Message); // somebody forgot to check!
        args.SetObserved();
    };
