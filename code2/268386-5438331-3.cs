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
            ActionHelper helper = new ActionHelper();        
            Random rng = new Random();
            helper.counter = rng.Next(10);
            Console.WriteLine("Initial value for counter: {0}", helper.counter);
            
            // Converts method group to a delegate, whose target will be a
            // reference to the instance of ActionHelper
            return helper.DoAction;
        }
        
        class ActionHelper
        {
            // Just for simplicity, make it public. I don't know if the
            // C# compiler really does.
            public int counter;
            
            public void DoAction()
            {
                Console.WriteLine(counter);
                counter++;
            }
        }
    }
