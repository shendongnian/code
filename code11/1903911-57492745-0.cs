    public static IPropagatorBlock<Point, Point[]> CreateBatchByCurrencyBlock(
        int batchSize)
    {
        var grouped = new Dictionary<string, List<Point>>(
            StringComparer.OrdinalIgnoreCase);
        var outgoing = new BufferBlock<Point[]>();
        var incoming = new ActionBlock<Point>(async point =>
        {
            List<Point> list;
            if (!grouped.TryGetValue(point.Currency, out list))
            {
                list = new List<Point>();
                grouped.Add(point.Currency, list);
            }
            list.Add(point);
            if (list.Count >= batchSize)
            {
                await outgoing.SendAsync(list.ToArray()).ConfigureAwait(false);
                list.Clear();
            }
        });
        incoming.Completion.ContinueWith(async t =>
        {
            if (t.Status == TaskStatus.RanToCompletion)
            {
                foreach (var list in grouped.Values)
                {
                    if (list.Count >= 0)
                    {
                        await outgoing.SendAsync(list.ToArray())
                            .ConfigureAwait(false);
                        list.Clear();
                    }
                }
            }
            else if (t.IsFaulted)
            {
                ((ITargetBlock<Point[]>)outgoing).Fault(t.Exception.InnerException);
            }
            outgoing.Complete();
        }, default, TaskContinuationOptions.ExecuteSynchronously,
        TaskScheduler.Default);
        return DataflowBlock.Encapsulate(incoming, outgoing);
    }
