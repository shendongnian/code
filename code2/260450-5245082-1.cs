    class Program
    {
        // example methods
        static void Method1()
        {
            Console.WriteLine("incomplete");
        }
        static void Method2()
        {
            Console.WriteLine("approved");
        }
        static void Method3()
        {
            Console.WriteLine("submitted");
        }
        static void Main(string[] args)
        {
            int targetId = 1; // or passed in id etc
            var actions = 
                new Dictionary<int, Action>
                  {
                      {1, () => Method1()},
                      {2, () => Method2()},
                      {3, () => Method3()}
                  };
            if (actions.ContainsKey(targetId))
            {
                actions[targetId].Invoke();
            }
            else
            {
                // no method defined for this action
                // do something about it
            }
            Console.ReadKey();
        }
    }
