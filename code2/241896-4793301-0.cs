    class Program
        {
            static void Main(string[] args)
            {
              var ints = Observable.Interval(TimeSpan.FromMilliseconds(1000))
                 .Publish(new Subject<long>());
        
              var windowed = ints.Window(() => ints.Where(i => i != 0 && (i + 1) % 3 == 0));
        
              windowed.Subscribe(HandleNewWindow);
        
              Console.ReadLine();
            }
        
            public static void HandleNewWindow(IObservable<long> ints)
            {
              Console.WriteLine("New sequence received");
              ints.Subscribe(Console.WriteLine);
            }
          }
