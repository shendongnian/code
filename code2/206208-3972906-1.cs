    public bool TryAdd(KeyValuePair<int, T> item)
    {
        int pos = _queues.Take(item.Key + 1).Sum(q => q.Count);
        _queues[item.Key].Enqueue(item.Value);
        Interlocked.Increment(ref _count);
        Dispatcher.BeginInvoke(
            new Action(
                () =>
                NotifyCollectionChanged(
                    new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, pos))
            ));
        return true;
    }
