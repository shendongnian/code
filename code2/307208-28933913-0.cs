    var delay = TimeSpan.FromSeconds(1.0);
    var actual = source.Scan(
        new ConcurrentQueue<object>(),
        (q, i) =>
            {
                q.Enqueue(i);
                return q;
            }).CombineLatest(
                Observable.Interval(delay),
                (q, t) =>
                    {
                        object item;
                        if (q.TryDequeue(out item))
                        {
                            return item;
                        }
                        return null;
                    }).Where(v => v != null);
