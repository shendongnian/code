    public static IObservable<IList<T>> SlidingBuffer<T>(this IObservable<T> obs, TimeSpan span, int max)
            {
                return Observable.CreateWithDisposable<IList<T>>(cl =>
                {
                    var acc = new List<T>();
                    return obs.Buffer(span)
                            .Subscribe(next =>
                            {
                                if (next.Count == 0) //no activity in time span
                                {
                                    cl.OnNext(acc);
                                    acc.Clear();
                                }
                                else
                                {
                                    acc.AddRange(next);
                                    if (acc.Count >= max) //max items collected
                                    {
                                        cl.OnNext(acc);
                                        acc.Clear();
                                    }
                                }
                            }, err => cl.OnError(err), () => { cl.OnNext(acc); cl.OnCompleted(); });
                });
            }
