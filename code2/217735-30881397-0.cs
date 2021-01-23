    TestScheduler scheduler = new TestScheduler();
    Task task = Task.Run(() =>
                    {
                        int i = 0;
                        while (i < 5)
                        {
                            Console.WriteLine(i);
                            i++;
                            Thread.Sleep(1000);
                        }
                    })
                    .TimeoutAfter(TimeSpan.FromSeconds(5), scheduler)
                    .ContinueWith(t => { }, TaskContinuationOptions.OnlyOnFaulted);
    
    scheduler.AdvanceBy(TimeSpan.FromSeconds(6).Ticks);
