    timer.Elapsed += (s,e) => {
        var list = events.Where( item => item.Key <= DateTime.Now ).ToList();
        foreach (var item in list)
        {
            item.Value.Invoke();
            events.TryRemove(item);
        }
    };
