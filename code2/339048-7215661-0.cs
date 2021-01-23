    static void Main(string[] args)
    {
        var xs = Enumerable.Range(1, 10);
        foreach (var x in xs)
        {
            Console.WriteLine(x);
        }
        //at this point, all values have been written
        var ys = Observable.Range(1, 10);
        ys.Subscribe(y => Console.WriteLine(y));
        //at this point, no values have been written (in general)
        //either add a Console.ReadKey or some sort of wait handle that
        //is set in the OnCompleted of the observer to get values
    }
