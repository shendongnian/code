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
                                    var ret = new List<T>(acc);
                                    acc.Clear();
                                    cl.OnNext(ret);
                                }
                                else if (acc.Count >= max) //max items collected
                                {
                                    var ret = new List<T>(acc);
                                    acc.Clear(); acc.AddRange(next);
                                    cl.OnNext(ret);
                                }
                                else
                                {
                                    acc.AddRange(next);//keep accumulating
                                }
                            }, err => cl.OnError(err), () => { cl.OnNext(acc); cl.OnCompleted(); });
                });
            }
