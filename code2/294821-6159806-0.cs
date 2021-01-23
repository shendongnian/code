        // Queue of items to process
        static ConcurrentQueue<string> queue;
        // Random number generator to simulate time it takes to do work.
        static Random rnd = new Random();
        
        static void Main(string[] args)
        {
            // Items to process.
            List<string> names = new List<string>() { "Joe", "Bob", "Fred", "Jack", "Jill", 
                "Suzy", "Amy", "Alice", "Andy", "Bill", "Chuck" };
            
            // Demonstrates putting the items into a concurrent queue.
            queue = new ConcurrentQueue<string>(names);
            // Work threads
            Thread first = new Thread(AddToDatabase);
            Thread second = new Thread(AddToDatabase);
            // Start the work threads
            first.Start("First");
            second.Start("Second");
        }
        // Simulated work routine.
        static void AddToDatabase(object state)
        {
            string name;
            while (queue.TryDequeue(out name))
            {
                Console.WriteLine(string.Concat(state, ": Putting ", name, " in the database."));
                Thread.Sleep(rnd.Next(1000, 5000));
            }
        }
