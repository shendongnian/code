    class Program
    {
        delegate void SomeTimeLaterDelegate(int myValue);
        delegate void SayHelloDelegate(string name);
        static event SomeTimeLaterDelegate SomeTimeLaterEvent;
        static event SayHelloDelegate SayHelloLaterEvent;
        static void Main(string[] args)
        {
            SomeTimeLaterEvent += new SomeTimeLaterDelegate(AnswerAnotherDay);
            SayHelloLaterEvent += new SayHelloDelegate(SayHello);
            var eventsToRaise = new Queue<Action>();
            eventsToRaise.Enqueue(() => SomeTimeLaterEvent.Invoke(100));
            eventsToRaise.Enqueue(() => SayHelloLaterEvent.Invoke("Bob"));
            eventsToRaise.Enqueue(() => SomeTimeLaterEvent.Invoke(200));
            eventsToRaise.Enqueue(() => SayHelloLaterEvent.Invoke("John"));
            while (eventsToRaise.Any())
            {
                var eventToRaise = eventsToRaise.Dequeue();
                eventToRaise();
                //or eventToRaise.Invoke();
            }
            Console.ReadLine();
        }
        static void AnswerAnotherDay(int howManyDays)
        {
            Console.WriteLine($"I did this {howManyDays}, later. Hurray for procrastination!");
        }
        static void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name}");
        }
    }
