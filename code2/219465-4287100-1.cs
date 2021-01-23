    class Program
    {
        public event EventHandler<EventArgs> MyEvent;
        static void Main(string[] args)
        {
            var myClass = new Program();            
     
            var task = new Task(() =>
            {
                for(var i=0; i<5; i++) {
                    // Generate standard .NET event. 
                    myClass.MyEvent(myClass, new EventArgs());
                }
               
                throw new Exception();
            });
            var obsTask = task.ToObservable();
            var events = Observable.FromEvent<EventArgs>(h => myClass.MyEvent += h, h => myClass.MyEvent -= h);            
                 
            events.TakeUntil(obsTask).Subscribe(
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
