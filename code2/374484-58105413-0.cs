            var arg = new { i = 123, j = 456 };
            var task = new TaskFactory().StartNew(new Func<dynamic, int>((argument) =>
            {
                dynamic x = argument.i * argument.j;
                return x;
            }), arg, CancellationToken.None, TaskCreationOptions.AttachedToParent, TaskScheduler.Default);
            task.Wait();
            var result = task.Result;
