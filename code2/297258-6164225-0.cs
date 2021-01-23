    public static class MyObservableExtensions
    {
        public static IObservable<IList<T>> BufferWithPredicate<T>(this IObservable<T> input, Func<T, IList<T>, bool> predicate)
        {
            return Observable.Defer(() =>
                {
                    var result = new Subject<IList<T>>();
                    var list = new List<T>();
                    input.Subscribe(item =>
                        {
                            if (predicate(item, list))
                            {
                                list.Add(item);
                            }
                            else
                            {
                                result.OnNext(list);
                                list = new List<T>();
                                list.Add(item);
                            }
                        }, 
                        () => result.OnNext(list));
                    return result;
                });
        }
    }
