    public IObservable<int> AddNumbers(int a, int b) {
        return Observable.Return(a + b);  
    }
    public IObservable<int> AddNumbersAsync(int a, int b) {
        return Observable.Start(() => a + b, Scheduler.NewThread);
    }
