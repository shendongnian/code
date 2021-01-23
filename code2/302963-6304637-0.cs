    public class MyClass : Event
    {
        private ThisClass _sender;        
        public MyClass(int milliseconds, ThisClass sender)
            : base(milliseconds)
        {
            _sender = sender;
        }
        public override void doWork()
        {
            _sender.stop();
            Console.WriteLine("yaya 5 seconds later");
        }
    }
