        class Program
        {
            class ProcessedEven
            {
                public int ProcessedInt { get; set; }
    
                public DateTime ProcessedValue { get; set; }
            }
    
            class ProcessedOdd
            {
                public int ProcessedInt { get; set; }
    
                public string ProcessedValue { get; set; }
            }
    
            static void Main(string[] args)
            {
                Stopwatch stopwatch = new Stopwatch();
    
                IEnumerator<int> enumerator = Enumerable.Range(0, 100000).GetEnumerator();
                ConcurrentDictionary<int, ProcessedOdd> processedOddValuesDictionary = new ConcurrentDictionary<int, ProcessedOdd>();
                ConcurrentDictionary<int, ProcessedEven> processedEvenValuesDictionary = new ConcurrentDictionary<int, ProcessedEven>();
    
                stopwatch.Start();
    
                while (enumerator.MoveNext())
                {
                    int currentNumber = enumerator.Current;
    
                    if (currentNumber % 2 == 0)
                    {
                        Task.Run(() =>
                        {
                            ProcessedEven processedEven =
                                new ProcessedEven { ProcessedInt = currentNumber, ProcessedValue = DateTime.Now.AddMinutes(currentNumber) };
                            Task.Delay(100);
    
                            processedEvenValuesDictionary.TryAdd(currentNumber, processedEven);
                        });
                    }
                    else
                    {
                        Task.Run(() =>
                        {
                            ProcessedOdd processedOdd =
                                new ProcessedOdd { ProcessedInt = currentNumber, ProcessedValue = Math.Pow(currentNumber, 4).ToString() };
                            Task.Delay(100);
    
                            processedOddValuesDictionary.TryAdd(currentNumber, processedOdd);
                        });
                    }
                }
    
                stopwatch.Stop();
    
                Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
    
                Console.ReadKey();
            }
        }
