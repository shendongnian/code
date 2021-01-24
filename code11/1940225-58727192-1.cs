    timer.Elapsed += (s,e) => {
        var list = events.Where( x => x.Key <= DateTime.Now ).ToList();
        foreach (var item in list)
        {
            item.Value.Invoke();
            events.TryRemove(item);
        }
    };
