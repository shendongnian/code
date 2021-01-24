    class Program
    {
        static void Main(string[] args)
        {
            var eventsToRaise = new Queue<Action>();
            eventsToRaise.Enqueue(() => AnswerAnotherDay(100));
            eventsToRaise.Enqueue(() => SayHello("Bob"));
            eventsToRaise.Enqueue(() => AnswerAnotherDay(200));
            eventsToRaise.Enqueue(() => SayHello("John"));
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
