    public static IObservable<T> 
    AtLeastEvery<T>(this IObservable<T> source, TimeSpan timeout, 
                    T defaultValue, IScheduler scheduler)
    {
        if (source == null) throw new ArgumentNullException("source");
        if (scheduler == null) throw new ArgumentNullException("scheduler");
        return Observable.Create<T>(obs =>
            {
                ulong id = 0;
                var gate = new Object();
                var timer = new SerialDisposable();
                T lastValue = defaultValue;
                Action createTimer = () =>
                    {
                        ulong startId = id;
                        timer.Disposable = scheduler.Schedule(timeout,
                              self =>
                              {
                                  bool noChange;
                                  lock (gate)
                                  {
                                      noChange = (id == startId);
                                      if (noChange) obs.OnNext(lastValue);
                                  }
                                  //only restart if no change, otherwise
                                  //the change restarted the timeout
                                  if (noChange) self(timeout);
                              });
                    };
                //start the first timeout
                createTimer();
                var subscription = source.Subscribe(
                    v =>
                    {
                        lock (gate)
                        {
                            id += 1;
                            lastValue = v;
                        }
                        obs.OnNext(v);
                        createTimer(); //reset the timeout
                    },
                    ex =>
                    {
                        lock (gate)
                        {
                            id += 1; //'cancel' timeout
                        }
                        obs.OnError(ex);
                        //do not reset the timeout, because the sequence has ended
                    },
                    () =>
                    {
                        lock (gate)
                        {
                            id += 1; //'cancel' timeout
                        }
                        obs.OnCompleted();
                        //do not reset the timeout, because the sequence has ended
                    });
                return new CompositeDisposable(timer, subscription);
            });
    }
