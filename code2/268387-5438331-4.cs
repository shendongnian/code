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
            int counter = 0;
            Action show = () => { Console.WriteLine(counter); };
            Action increment = () => { counter++; };
            return Tuple.Create(show, increment);
        }
    }
