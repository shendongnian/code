    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        IEnumerable<int> enumerable = Enumerable.Range(0, 100000);
        ConcurrentDictionary<int, ProcessedOdd> processedOddValuesDictionary = new ConcurrentDictionary<int, ProcessedOdd>();
        ConcurrentDictionary<int, ProcessedEven> processedEvenValuesDictionary = new ConcurrentDictionary<int, ProcessedEven>();
        stopwatch.Start();
        Parallel.ForEach(enumerable,
            currentNumber =>
                {
                    if (currentNumber % 2 == 0)
                    {
                        ProcessedEven processedEven =
                            new ProcessedEven { ProcessedInt = currentNumber, ProcessedValue = DateTime.Now.AddMinutes(currentNumber) };
                        // Task.Delay(100);
                        processedEvenValuesDictionary.TryAdd(currentNumber, processedEven);
                    }
                    else
                    {
                        ProcessedOdd processedOdd =
                            new ProcessedOdd { ProcessedInt = currentNumber, ProcessedValue = Math.Pow(currentNumber, 4).ToString() };
                        // Task.Delay(100);
                        processedOddValuesDictionary.TryAdd(currentNumber, processedOdd);
                    }
                });
        
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
        Console.ReadKey();
    }
