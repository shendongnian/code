    public static IObservable<string> MergeJoin(
        IObservable<int> left, IObservable<int> right, Func<int, int, string> selector)
    {
        return Observable.CreateWithDisposable<string>(o =>
        {
            Queue<int> a = new Queue<int>();
            Queue<int> b = new Queue<int>();
            object gate = new object();
            bool leftComplete = false;
            bool rightComplete = false;
            MutableDisposable leftSubscription = new MutableDisposable();
            MutableDisposable rightSubscription = new MutableDisposable();
            Action tryDequeue = () =>
            {
                lock (gate)
                {
                    while (a.Count != 0 && b.Count != 0)
                    {
                        if (a.Peek() == b.Peek())
                        {
                            try
                            {
                                o.OnNext(selector(a.Dequeue(), b.Dequeue()));
                            }
                            catch (Exception ex)
                            {
                                o.OnError(ex);
                            }
                        }
                        else if (a.Peek() < b.Peek())
                        {
                            a.Dequeue();
                        }
                        else
                        {
                            b.Dequeue();
                        }
                    }
                }
            };
            leftSubscription.Disposable = left.Subscribe(x =>
            {
                lock (gate)
                {
                    if (a.Count == 0 || a.Peek() < x)
                        a.Enqueue(x);
                    tryDequeue();
                    if (rightComplete && b.Count == 0)
                    {
                        o.OnCompleted();
                    }
                }
            }, () =>
            {
                leftComplete = true;
                if (a.Count == 0 || rightComplete)
                {
                    o.OnCompleted();
                }
            });
            rightSubscription.Disposable = right.Subscribe(x =>
            {
                lock (gate)
                {
                    if (b.Count == 0 || b.Peek() < x)
                        b.Enqueue(x);
                    tryDequeue();
                    if (rightComplete && b.Count == 0)
                    {
                        o.OnCompleted();
                    }
                }
            }, () =>
            {
                rightComplete = true;
                if (b.Count == 0 || leftComplete)
                {
                    o.OnCompleted();
                }
            });
            return new CompositeDisposable(leftSubscription, rightSubscription);
        });
    }
