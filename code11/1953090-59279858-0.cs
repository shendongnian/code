        static void Main(string[] args)
        {
            BlockingCollection<long> objectPool = new BlockingCollection<long>();
            Task.Factory.StartNew(() =>
            {
                long counter = 0;
                try
                {
                    while (counter < long.MaxValue)
                    {
                        if (++counter % 1000 == 0)
                        {
                            objectPool.TryAdd(counter);
                        }
                    }
                    objectPool.CompleteAdding();
                }
                catch
                {
                    //after completeadding is called by this task, 
                    //the another task will break the foreach statement.
                    objectPool.CompleteAdding();
                }
            });
            Task.Factory.StartNew(() =>
            {
               //Will block and wait until there are consumable objects.
               foreach(var obj in objectPool.GetConsumingEnumerable())
               {
                    Console.WriteLine(obj);//consume the object
               }
            });
        }
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent.blockingcollection-1?view=netframework-4.8
