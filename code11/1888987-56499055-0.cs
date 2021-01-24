    // Demonstrates:
    //      BlockingCollection<T>.Add()
    //      BlockingCollection<T>.CompleteAdding()
    //      BlockingCollection<T>.TryTake()
    //      BlockingCollection<T>.IsCompleted
    public static void BC_TryTake()
    {
        // Construct and fill our BlockingCollection
        using (BlockingCollection<int> bc = new BlockingCollection<int>())
        {
            int NUMITEMS = 10000;
            for (int i = 0; i < NUMITEMS; i++) bc.Add(i);
            bc.CompleteAdding();
            int outerSum = 0;
            // Delegate for consuming the BlockingCollection and adding up all items
            Action action = () =>
            {
                int localItem;
                int localSum = 0;
                while (bc.TryTake(out localItem)) localSum += localItem;
                Interlocked.Add(ref outerSum, localSum);
            };
            // Launch three parallel actions to consume the BlockingCollection
            Parallel.Invoke(action, action, action);
            Console.WriteLine("Sum[0..{0}) = {1}, should be {2}", NUMITEMS, outerSum, 
                ((NUMITEMS*(NUMITEMS - 1))/2));
            Console.WriteLine("bc.IsCompleted = {0} (should be true)", bc.IsCompleted);
        }
    }
