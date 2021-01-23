    class Program
    {
        static void Main(string[] args)
        {
            var class1 = new FirstClass();
            class1.Foo += EventRaised;
            class1.ChangeFoo("TEST");
        }
        static void EventRaised(string arg)
        {
            Console.WriteLine(arg);
        }
    }
