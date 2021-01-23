    public static IObservable<int> GetObs(int i)
    {
       return Observable.Return(i).Delay(TimeSpan.FromMilliseconds(10));
    }
    public static IObservable<int> MakeInts(int start)
    {
       return Observable.Generate(start, _ => true, i => i + 1, i => GetObs(i))
                    .SelectMany(obs => obs);
    }
    
    
    using (MakeInts(1).Subscribe(Console.WriteLine))
    {
        Console.ReadLine();
    }
