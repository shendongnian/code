    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            Action first = () => Console.WriteLine("First");
            Action second = () => Console.WriteLine("Second");
            
            Action both = first + second;
            Action wrapped1 =
                (Action) Delegate.CreateDelegate(typeof(Action),
                                                 both.Target, both.Method);
            Action wrapped2 = new Action(both);
            
            Console.WriteLine("Calling wrapped1:");
            wrapped1();
    
            Console.WriteLine("Calling wrapped2:");
            wrapped2();
        }
    }
