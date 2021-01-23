            // Exceptions thrown by tasks will be propagated to the main thread
        // while it waits for the tasks. The actual exceptions will be wrapped in AggregateException.
        try
        {
            // Wait for all the tasks to finish.
            Task.WaitAll(tasks);
            // We should never get to this point
            Console.WriteLine("WaitAll() has not thrown exceptions. THIS WAS NOT EXPECTED.");
        }
        catch (AggregateException e)
        {
            Console.WriteLine("\nThe following exceptions have been thrown by WaitAll(): (THIS WAS EXPECTED)");
            for (int j = 0; j < e.InnerExceptions.Count; j++)
            {
                Console.WriteLine("\n-------------------------------------------------\n{0}", e.InnerExceptions[j].ToString());
            }
        }
