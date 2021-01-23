    public static IObservable<IList<T>> SlidingBuffer<T>(this IObservable<T> obs, TimeSpan span, int max)
            {
                var acc = new List<T>();
                return obs.Buffer(span)
                        .Select(ls =>
                        {
                            if (ls.Count == 0) //no activity in time span
                            {
                                var ret = new List<T>(acc);
                                acc.Clear();
                                return ret;
                            }
                            else if (acc.Count >= max) //max items collected
                            {
                                var ret = new List<T>(acc);
                                acc.Clear(); acc.AddRange(ls);
                                return ret;
                            }
                            else
                            {
                                acc.AddRange(ls);
                                return null; //keep accumulating
                            }
                        }).Where(ls => ls != null);
            }
