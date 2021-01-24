    static void Main(string[] args)
    {
        const int firstValue = 30;
        const int secondValues = 20;
        const int thirdValues = 10;
    
        var process = new BlockingCollection<int>() { firstValue };
    
        var parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount };
        int totalItemCount = process.Count;
    
        OrderablePartitioner<int> partitioner = Partitioner.Create(process.GetConsumingEnumerable(), EnumerablePartitionerOptions.NoBuffering);
    
        Parallel.ForEach(partitioner, parallelOptions, (item, state, i) =>
        {
            string message;
    
            if (item > secondValues)
            {
                // Some add 2 items
                Interlocked.Add(ref totalItemCount, 2);
                process.Add(item - 1);
                process.Add(item - 1);
                message = $"{DateTime.Now.ToLongTimeString()}: process.Count: {process.Count} | item: {item} | Added: 2";
            }
            else if (item > thirdValues)
            {
                // Some add 1 item
                Interlocked.Increment(ref totalItemCount);
                process.Add(item - 1);
                message = $"{DateTime.Now.ToLongTimeString()}: process.Count: {process.Count}| item: {item} | Added: 1";
            }
            else
            {
                // Some add 0 items
                message = $"{DateTime.Now.ToLongTimeString()}: process.Count: {process.Count}| item: {item} | Added: 0";
            }
    
            int newCount = Interlocked.Decrement(ref totalItemCount);
    
            if (newCount == 0)
            {
                process.CompleteAdding();
            }
    
            Console.WriteLine($"{message} | newCount: {newCount} | i: {i}");
        });
    
        // Parallel.ForEach will exit
        Console.WriteLine("Completed Processing");    
        Console.ReadKey();
    }
