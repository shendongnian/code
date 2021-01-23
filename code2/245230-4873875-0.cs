       var observable = Observable.Timer(
                      TimeSpan.FromMinutes(1), 
                      TimeSpan.FromMinutes(1)).Timestamp();
        using (observable.Subscribe()))
        {
             DoAutoSave();
        }
