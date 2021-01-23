    using System;
    
    class Test
    {
        static void Main(string[] args)
        {
            Action[] actions = new Action[2];
            for (int i = 0; i < 2; i++)
            {
                actions[i] = () => Console.WriteLine("Hello");
            }
            Console.WriteLine(actions[0] == actions[1]);
        }
    }
