    if (startWithCurrent)
    {
        newValues = Observable.Defer(() => Observable.Return(reader(notifier))
                              .Concat(newValues));
    }
    return Observable.Create<Tuple<TProperty, TProperty>>(obs =>
        {
            Tuple<TProperty, TProperty> oldNew = null;
            return newValues.Subscribe(v =>
                {
                    if (oldNew == null)
                    {
                        oldNew = Tuple.Create(default(TProperty), v);
                    }
                    else
                    {
                        oldNew = Tuple.Create(oldNew.Item2, v);
                        obs.OnNext(oldNew);
                    }
                },
                obs.OnError,
                obs.OnCompleted);
        });
