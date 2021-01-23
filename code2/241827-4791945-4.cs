        AppDomain.CurrentDomain.UnhandledException +=
            (sender, eventArgs) => Console.WriteLine("unHandled " + eventArgs.ExceptionObject.GetType().FullName);
        try
        {
            new TestComponent();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Handled " + ex.GetType().FullName);
        }
        Console.WriteLine("happy");
