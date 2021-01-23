    using System;
    
    class Test
    {
        static void Main()
        {
            Action action = CreateShowAndIncrementAction();
            action();
            action();
        }
        
        static Action CreateShowAndIncrementAction()
        {
            Random rng = new Random();
            int counter = rng.Next(10);
            Console.WriteLine("Initial value for counter: {0}", counter);
            return () =>
            {
                Console.WriteLine(counter);
                counter++;
            };
        }
    }
