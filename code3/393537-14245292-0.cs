        TaskScheduler scheduler = TaskScheduler.Default;
            var fetchTask = Task<Boolean>.Factory.StartNew(() =>
            {
                while (1 == 1)
                {
                    try
                    {
                        IDataObject obj = Clipboard.GetDataObject();
                        return true;
                    }
                    catch (Exception e)
                    {
                    }
                }
            })
            .ContinueWith<Boolean>(
                x =>
                {
                    Console.WriteLine("Task completed");
                    return true;
                },
            CancellationToken.None,
            TaskContinuationOptions.None, scheduler);
