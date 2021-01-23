    class Program
    {
        static void Main(string[] args)
        {
            var ints = Observable.Interval(TimeSpan.FromMilliseconds(1000))
                .Publish(new Subject<long>());
    
            var closeOnValues = ints.Where(ShouldClose);
    
            var windowed = ints.Window(() => closeOnValues);
    
            windowed.Subscribe(HandleNewWindow);
    
            Console.ReadLine();
        }
    
        public static void HandleNewWindow(IObservable<long> ints)
        {
            Console.WriteLine("New sequence received");
            ints.Subscribe(Console.WriteLine);
        }
    
        public static bool ShouldClose(long index)
        {
            var notZero = index != 0;
            var countIsMultipleOfThree = (index + 1) % 3 == 0;
    
            return notZero && countIsMultipleOfThree;
        }
    }
