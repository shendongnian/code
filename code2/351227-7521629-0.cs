    Subject<int> _myObservable = new Subject<int>(); 
    void ThingsCallMe(int someImportantNumber)
    {
        // Current pseudo-code seeking to be replaced with something that would compile?
        _myObservable.OnNext(someImportantNumber);
    }
    void ISpyOnThings()
    {
        _myObservable.Subscribe(
            i =>
            Console.WriteLine("stole your number " + i.ToString()));
    }
