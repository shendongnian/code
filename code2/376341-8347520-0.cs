    private void button1_Click(object sender, EventArgs e) {
      var countObserver = Observable.Create<int>(observer => {
        var cancel = new CancellationDisposable();
        // Here's the magic: schedule the job in background and return quickly
        var scheduledItem = Scheduler.ThreadPool.Schedule(() =>
        {
          if (!cancel.Token.IsCancellationRequested) {
            //Step 1 of a long running process using lot of resources...
            observer.OnNext(1);
          }
          if (!cancel.Token.IsCancellationRequested) {
            //Step 2 of a long running process using lot of resources...
            observer.OnNext(1);
          }
          if (!cancel.Token.IsCancellationRequested) {
            //Step 3 of a long running process using lot of resources...
            observer.OnNext(1);
          }
          observer.OnCompleted();
        });
        return new CompositeDisposable(cancel, scheduledItem);
    });
    obs = countObserver
        .ObserveOn(new ControlScheduler(this))
        .Subscribe(i => {
            //Update a progress bar here...
        });
    }
