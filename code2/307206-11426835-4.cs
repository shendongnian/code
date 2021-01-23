    static void Main()
    {
        TimeSpan period = TimeSpan.FromMilliseconds(1000);
        TimeSpan recovery = TimeSpan.FromMilliseconds(200);
    
        Observable
            .Repeat(Unit.Default)
            .Select(_ =>
            {
                var s = DateTimeOffset.Now;
                var x = compute();
                var delay = period - (DateTimeOffset.Now - s);
                if (delay < recovery)
                    delay = recovery;
    
                Console.Write("+{0} ", (int)delay.TotalMilliseconds);
    
                return Observable.Return(x).Delay(delay).First();
            })
            .Subscribe(Console.WriteLine);
    }
