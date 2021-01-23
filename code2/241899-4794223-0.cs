    class Program
    {
        static void Main(string[] args)
        {
            var ints = Observable.Interval(TimeSpan.FromMilliseconds(1000));
            var windowClosings = ints
                .Select(i => i / 3)
                .DistinctUntilChanged()
                .SkipWhile((i) => i == 0)
                .Publish(new Subject<long>());
            var windowed = ints.Window(() => windowClosings);
    
            windowed.Subscribe(HandleNewWindow);
    
            Console.ReadLine();
        }
    
        public static void HandleNewWindow(IObservable<long> ints)
        {
            Console.WriteLine("New sequence received");
            ints.Subscribe(Console.WriteLine);
        }
    }
