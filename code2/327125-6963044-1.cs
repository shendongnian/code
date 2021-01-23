    class Program
        {
            static void Main(string[] args)
            {
                TestStringCat(10);
                TestStringBuilder(10);
                TestStringCat(100);
                TestStringBuilder(100);
                TestStringCat(1000);
                TestStringBuilder(1000);
                TestStringCat(10000);
                TestStringBuilder(10000);
                TestStringCat(100000);
                TestStringBuilder(100000);
                TestStringCat(1000000);
                TestStringBuilder(1000000);
    
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
    
            static void TestStringCat(int iterations)
            {
                GC.Collect();
                String s = String.Empty;
                long memory = GC.GetTotalMemory(true);
                Stopwatch sw = Stopwatch.StartNew();
    
                for (int i = 0; i < iterations; i++)
                {
                    s += "a";
                }
    
                sw.Stop();
                memory = GC.GetTotalMemory(false) - memory;
    
                Console.WriteLine("String concat \t({0}):\t\t{1} ticks,\t{2} ms,\t\t{3} bytes", iterations, sw.ElapsedTicks, sw.ElapsedMilliseconds, memory);
            }
    
            static void TestStringBuilder(int iterations)
            {
                GC.Collect();
                StringBuilder sb = new StringBuilder();
                long memory = GC.GetTotalMemory(true);
                Stopwatch sw = Stopwatch.StartNew();
    
                for (int i = 0; i < iterations; i++)
                {
                    sb.Append("a");
                }
    
                sw.Stop();
                memory = GC.GetTotalMemory(false) - memory;
    
                Console.WriteLine("String Builder \t({0}):\t\t{1} ticks,\t{2} ms,\t\t{3} bytes", iterations, sw.ElapsedTicks, sw.ElapsedMilliseconds, memory);
            }
        }
