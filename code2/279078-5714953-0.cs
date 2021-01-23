        // No point in specifically surrounding the next 2 statements
        Task t1 = Task.Factory.StartNew(() => Foo());
        Task t2 = Task.Factory.StartNew(() => Bar());
        try
        {
            Task.WaitAll(t1, t2);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);  // Aggregated exceptions from Foo and/or Bar
        }
