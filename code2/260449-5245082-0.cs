    class Program
    {
        static void Main(string[] args)
        {
            int targetId = 2; // or passed in id etc
            var actions = 
                new Dictionary<int, Action>
                  {
                      {1, () => Console.WriteLine("incomplete")},
                      {2, () => Console.WriteLine("submitted")},
                      {3, () => Console.WriteLine("approved")}
                  };
            if (actions.ContainsKey(targetId)) actions[targetId].Invoke();
            Console.ReadKey();
        }
    }
