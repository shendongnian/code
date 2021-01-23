    using System;
    
    class Program
    {
        static void Main()
        {
            Action first = GetFirstAction();
            first -= GetFirstAction();
            Console.WriteLine(first == null); // Prints True
    
            Action second = GetSecondAction();
            second -= GetSecondAction();
            Console.WriteLine(second == null); // Prints False
        }
        
        static Action GetFirstAction()
        {
            return () => Console.WriteLine("First");
        }
    
        static Action GetSecondAction()
        {
            int i = 0;
            return () => Console.WriteLine("Second " + i);
        }
    }
