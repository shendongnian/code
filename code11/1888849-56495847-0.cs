    public void UpdateWithPercent(ref ConcurrentDictionary<string, Book> refList, List<Book> list, int ticker, int maxTimes)
    {
        var size = list.Count;
        int numProcs = Environment.ProcessorCount;
        var divider = CalculatBiggestDivider(size);
        var nextIteration = 0;
        var remainingWork = numProcs;
        var internalRefList = refList;
        using (ManualResetEvent mre = new ManualResetEvent(false))
        {
            for (int i = 0; i < numProcs; i++)
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    int index = 0;
                    while ((index = Interlocked.Add(ref nextIteration, divider) - divider) < size)
                    {
                        foreach (var item in list.GetRange(index, divider))
                        {
                            Book x;
                            if (internalRefList.TryGetValue(item.Title, out x))
                            {
    								x.Orders += item.Orders;
                            }
                        };
                    }
    
                    if (Interlocked.Decrement(ref remainingWork) == 0)
                    {
                        mre.Set();
                    }
                });
            }
    
            mre.WaitOne();
        }
    
        refList = internalRefList;
    }
