    class Program
    {
        static void Main(string[] args)
        {
            Func<int, IEnumerable<int>> func = x =>
            {
                return Enumerable.Range(0, x);
            };
            CompositeDisposable subsriptions = new CompositeDisposable();
            for (int i = 1; i < 10; i++)
            {
                var observable = func(i).ToObservable().ToList();
                var subscription = observable.Subscribe(x => Console.WriteLine(x.Select(y => y.ToString()).Aggregate((s1, s2) => s1 + "," + s2)));
                subsriptions.Add(subscription);
            }
            Console.ReadLine();
            subsriptions.Dispose();
        }
    }
