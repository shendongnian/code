    using System.Windows.Threading;
    if (Environment.GetCommandLineArgs().Count() > 1)
    {
        var dispatcher = Dispatcher.CurrentDispatcher;
        var invokeTask = Task.Run(async () =>
        {
            try
            {
                await dispatcher.Invoke(async () =>
                {
                    using (MyCustomConsole mcc = new MyCustomConsole())
                    {
                        await mcc.Run();
                    }
                });
            }
            finally
            {
                dispatcher.InvokeShutdown();
            }
        });
        Dispatcher.Run(); // blocking call
        await invokeTask; // await the task just to propagate exceptions
    }
