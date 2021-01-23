    class Program
    {
        // example methods
        static void Method1(string message)
        {
            Console.WriteLine(message);
        }
        static void Method2(int id, string message)
        {
            Console.WriteLine(string.Format("id: {0} message: {1}", id, message));
        }
        static void Method3()
        {
            Console.WriteLine("submitted");
        }
        static void Main(string[] args)
        {
            int targetId = 2; // or passed in id etc
            // add the actions with examples of params
            // and non param methods
            var actions = 
                new Dictionary<int, Action>
                      {
                          {1, () => Method1("incomplete")}, 
                          {2, () => Method2(targetId, "approved")},
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
                Console.WriteLine("no action defined here yet");
            }
            Console.ReadKey();
        }
    }
