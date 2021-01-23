    using(var ts = new TransactionScope())
    {
        try
        {
            List<Task> tasks = new List<Task>();
            for(some condition)
            {
                // get chunk of records
                // generate xml
                // create new task and call routing to push data to db
                var task = PushDataAsync(theData); // make the task
                tasks.Add(task); // Keep a reference in a collection
            }
            // Wait until all tasks are done, so you can complete the transaction...
            // If any task raises an exception, you'll get an AggregateException here
            Task.WaitAll(tasks.ToArray());
            ts.Complete();
        }
        catch(Exception ex)
        {
            //log exception and show user message
        }
    }
