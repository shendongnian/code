    public static IObservable<T> SortedMerge<T>(this IObservable<T> source, IObservable<T> other)
    {
        return SortedMerge(source, other, (a, b) => Enumerable.Min(new[] { a, b}));
    }
    public static IObservable<T> SortedMerge<T>(this IObservable<T> source, IObservable<T> other, Func<T, T, T> min)
    {
        return source
            .Select(i => (key: 1, value: i)).Materialize()
            .Merge(other.Select(i => (key: 2, value: i)).Materialize())
            .Scan((qA: ImmutableQueue<T>.Empty, qB: ImmutableQueue<T>.Empty, exception: (Exception)null, outputMessages: new List<T>()), 
                (state, message) =>
            {
                if (message.Kind == NotificationKind.OnNext)
                {
                    var key = message.Value.key;
                    var value = message.Value.value;
                    var qA = state.qA;
                    var qB = state.qB;
                    if (key == 1)
                        qA = qA.Enqueue(value);
                    else
                        qB = qB.Enqueue(value);
                    var output = new List<T>();
                    while(!qA.IsEmpty && !qB.IsEmpty)
                    {
                        var aVal = qA.Peek();
                        var bVal = qB.Peek();
                        var minVal = min(aVal, bVal);
                        if(aVal.Equals(minVal) && bVal.Equals(minVal))
                            throw new NotImplementedException();
                            
                        if(aVal.Equals(minVal))
                        {
                            output.Add(aVal);
                            qA = qA.Dequeue();
                        }
                        else
                        {
                            output.Add(bVal);
                            qB = qB.Dequeue();
                        }
                    }
                    return (qA, qB, null, output);
                }
                else if (message.Kind == NotificationKind.OnError)
                {
                    return (state.qA, state.qB, message.Exception, new List<T>());
                }
                else //message.Kind == NotificationKind.OnCompleted
                {
                    var output = state.qA.Concat(state.qB).ToList();
                    return (ImmutableQueue<T>.Empty, ImmutableQueue<T>.Empty, null, output);
                }
            })
            .Publish(tuples => Observable.Merge(
                tuples
                    .Where(t => t.outputMessages.Any() && (!t.qA.IsEmpty || !t.qB.IsEmpty))
                    .SelectMany(t => t.outputMessages
                        .Select(v => Notification.CreateOnNext<T>(v))
                        .ToObservable()
                ),
                tuples
                    .Where(t => t.outputMessages.Any() && t.qA.IsEmpty && t.qB.IsEmpty)
                    .SelectMany(t => t.outputMessages
                        .Select(v => Notification.CreateOnNext<T>(v))
                        .ToObservable()
                        .Concat(Observable.Return(Notification.CreateOnCompleted<T>()))
                ),
                tuples
                    .Where(t => t.exception != null)
                    .Select(t => Notification.CreateOnError<T>(t.exception))
            ))
            .Dematerialize();
