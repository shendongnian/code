    // For the number of threads + 1 for the main thread
    Barrier barrier = new Barrier(this.p_Contacts.count + 1);
    ConcurrentBag<Entry> entries = new ConcurrentBag<Entry>();
    foreach (Contact c in this.p_Contacts)
    {
        ThreadPool.RegisterWaitForSingleObject(
            new EventWaitHandle(false, EventResetMode.AutoReset),
            (stateInfo,timedOut) => {
                try
                {
                    FetchMessage fm = new FetchMessage(this, c, key);
                    fm.Send();
                    while(!fm.Received || !timedOut)
                    {
                        Thread.Sleep(100);
                    }
                    if(fm.Received)
                    {
                        foreach (Entry e in fm.Values)
                        {
                            entries.Add(e);
                            Console.WriteLine("Added " + e.Value + " to the entries.");
                        }
                        // avoid counting other thread's work
                        if (fm.Values.count == 0)
                        {
                            Console.WriteLine("There were no entries to add.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The node did not return in time.");
                    }
                    barrier.SignalAndWait();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }, null, TimeSpan.FromSeconds(1.5), true);
        );
    }
    // This limits total time waited to only 1.5 seconds
    barrier.SignalAndWait(TimeSpan.FromSeconds(1.5));
    return new List<Entry>(entries.ToArray());
