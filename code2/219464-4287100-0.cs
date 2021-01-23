       class Program
        {
            public event EventHandler<EventArgs> MyEvent;
            static void Main(string[] args)
            {
                var myClass = new Program();
    
                var task = new Task(() =>
                {
                    while (true)
                    {
                        // Generate standard .NET event. 
                        myClass.MyEvent(myClass, new EventArgs());
    
                        // Maybe throw exception. 
                        if (true) throw new Exception();
                    }
                });
    
                var obsTask = task.ToObservable();
    
                var events =
                    from e in Observable.FromEvent<EventArgs>(h => myClass.MyEvent += h, h => myClass.MyEvent -= h)
                    from t in obsTask
                    select e;
                     
                events.Subscribe(
                    ev => DoSomethingOnNext(ev),
                    ex => DoSomethingOnError(ex),
                    () => DoSomethingOnCompleted());
    
                task.Start();
    
                Console.ReadKey();
            }
    
            private static void DoSomethingOnCompleted()
            {
                Console.WriteLine("DoSomethingOnCompleted");
            }
    
            private static void DoSomethingOnError(Exception ex)
            {
                Console.WriteLine("DoSomethingOnError:" + ex.ToString());
            }
    
            private static void DoSomethingOnNext(IEvent<EventArgs> ev)
            {
                Console.WriteLine("DoSomethingOnNext:" + ev.ToString());
            }
        }
