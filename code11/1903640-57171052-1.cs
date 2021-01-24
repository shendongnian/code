using System;
using System.Collections.Generic;
using UniRx;
public static class ObservableFunctions
{
    public static IObservable<T[]> BufferWhen<T>(this IObservable<T> source, Predicate<T> predicate)
    {
        return Observable.Create<T[]>(observer =>
        {
            List<T> buffer = new List<T>();
            source.Subscribe(
                t =>
                {
                    if (predicate(t))
                    {
                        buffer.Add(t);
                    }
                    else
                    {
                        if (buffer.Count > 0)
                        {
                            observer.OnNext(buffer.ToArray());
                            buffer = new List<T>();
                        }
                    }
                },
                e =>
                {
                    observer.OnError(e);
                },
                () =>
                {
                    observer.OnCompleted();
                }
            );
            return Disposable.Empty;
        });
    }
}
Luckily it was very simple. Simplier than searching the appropriate function in Google...
