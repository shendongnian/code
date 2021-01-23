        class TrackedItem
        {
            public TrackedItem()
            {
                Console.WriteLine("Constructor!");
            }
            ~TrackedItem()
            {
                Console.WriteLine("Destructor!");
            }
        }
        static void Main(string[] args)
        {
            Action allCollect = () =>
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                };
            // create a single item and loose it directly thereafter
            TrackedItem item = new TrackedItem();
            item = null;
            allCollect();
            // Constructor!, Destructor!
            ConcurrentBag<TrackedItem> bag = new ConcurrentBag<TrackedItem>();
            bag.Add(new TrackedItem());
            bag = null;
            allCollect();
            // Constructor!
            // Note that the destructor was not called since there is still a collection on the local thread
            Console.ReadLine();
        }
