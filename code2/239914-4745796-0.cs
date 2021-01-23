    static class Program
    {
        static int GetSize() { return 10000; }
        static void Main() {
    
            int size = GetSize();
            int[] someData = new int[size];
    
            var watchInt32 = Stopwatch.StartNew();
            for (int i = 0; i < 5000; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    someData[j]++;
                }
            }
            for (int j = 0; j < size; j++) someData[j] = 0;
            watchInt32.Stop();
            long lSize = size;
            var watchInt64 = Stopwatch.StartNew();
            for (int i = 0; i < 5000; i++)
            {
                for (long j = 0; j < lSize; j++)
                {
                    someData[j]++;
                }
            }
            watchInt64.Stop();
    
            Console.WriteLine("{0}ms vs {1}ms over {2} iterations",
                (int)watchInt32.ElapsedMilliseconds,
                (int)watchInt64.ElapsedMilliseconds, 5000 * size);
        }
    }
