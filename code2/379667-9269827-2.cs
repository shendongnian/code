    public IEnumerable<IObservable<byte>> ConstantRead(string path)
    {
        while (true)
        {
            yield return Observable.Using(
                    () => new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None),
                    stream => stream.ToObservable(4096, Scheduler.ThreadPool));
        }
    }
