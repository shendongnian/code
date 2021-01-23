    var list = Observable.FromAsyncPattern<string[]>(client.BeginList, client.EndList);
    list().Subscribe(items =>
    {
        // items is the string[]
    });
