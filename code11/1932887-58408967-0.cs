    var task = Task.Run(async () =>
    {
        while (true) // Infinite retries
        {
            try
            {
                // Do something
            }
            catch (Exception e)
            {
                // Log the exception, but swallow it, so we retry
            }
        }
    });
