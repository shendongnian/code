       class Program
        {
            static void Main(string[] args)
            {
                SetArray(1, 10);
                SetArray(2, 10);
            }
    
            private static void SetArray(int checkValue, int nTimes)
            {
                const int N = 500_000_000;
                int[] values = new int[N]; // 4 GB
    
                for (int k = 0; k < nTimes; k++)  // set array values to 1
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = 1;
                    }
    
                    var sw = Stopwatch.StartNew();
                    Action acc = () =>
                    {
                        int tmp1 = 0;
                        for (int i = 0; i < values.Length; i++)
                        {
                            tmp1 = values[i];
                            if (tmp1 != checkValue)  // set only if not equal to checkvalue
                            {
                                values[i] = checkValue;
                            }
                        }
                    };
    
                    Parallel.Invoke(acc, acc, acc);  // Let this run on 3 cores
    
                    sw.Stop();
                    Console.WriteLine($"Set {N * 4 / (1_000_000_000.0f):F1} GB of Memory in {sw.Elapsed.TotalMilliseconds:F0} ms. Initial Value 1. Set Value {checkValue}");
                }
            }
        }
