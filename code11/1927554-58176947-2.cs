        private static async Task<T[]> RunAsyncThrottled<T>(IEnumerable<Func<Task<T>>> tasks, int maxDegreeOfParallelism)
        {
            var tasksParallelized = new List<Task<T>>();
            using (var semaphore = new SemaphoreSlim(maxDegreeOfParallelism))
            {
                foreach (var task in tasks)
                {
                    var taskParallelized = Task.Run(async () =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            return await task.Invoke();
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });
                    tasksParallelized.Add(taskParallelized);
                }
                return await Task.WhenAll(tasksParallelized);
            }
        }
        private static async Task<int> TestAsync(int num)
        {
            await Task.Delay(1000);
            return 1 + num;
        }
        static async Task Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            var tasks = new List<Func<Task<int>>>();
            var ints = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(() => TestAsync(12000));
            }
            ints.AddRange(await RunAsyncThrottled(tasks, 1000));
            Console.WriteLine($"{sw.Elapsed.TotalMilliseconds}, count: {ints.Count}");
            Console.ReadLine();
        }
    
