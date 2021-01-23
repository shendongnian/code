    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            var tuple = CreateShowAndIncrementActions();
            var show = tuple.Item1;
            var increment = tuple.Item2;
            
            show(); // Prints 0
            show(); // Still prints 0
            increment();
            show(); // Now prints 1
        }
        
        static Tuple<Action, Action> CreateShowAndIncrementActions()
        {
            ActionHelper helper = new ActionHelper();
            helper.counter = 0;
            Action show = helper.Show;
            Action increment = helper.Increment;
            return Tuple.Create(show, increment);
        }
        
        class ActionHelper
        {
            public int counter;
            
            public void Show()
            {
                Console.WriteLine(counter);
            }
            
            public void Increment()
            {
                counter++;
            }
        }
    }
