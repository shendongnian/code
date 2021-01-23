      public IObservable<Unit> OnUpdate(string path, string pattern)
            {
                return Observable.Create<Unit>(o =>
                {
                    var watcher = Files.WatchForChanges(path, pattern, () => o.OnNext(new Unit()));
    
                    return watcher;
                });
            }
