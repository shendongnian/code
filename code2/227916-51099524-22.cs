    using System;
    using System.Diagnostics;
    
    namespace ConsoleApp3
    {
        class Program
        {
            static void Main(string[] args)
            {
                RunTests_Int32();
                RunTests_Int64();
            }
    
            // Int32 Performance Tests:
            static void RunTests_Int32()
            {
                Console.WriteLine("\r\nInt32");
    
                const int size = 100000000;
                int[] samples = new int[size];
                Random random = new Random((int)DateTime.Now.Ticks);
                for (int i = 0; i < size; ++i)
                    samples[i] = random.Next(int.MinValue, int.MaxValue);
    
                Stopwatch sw1 = new Stopwatch();
                sw1.Start();
                for (int i = 0; i < size; ++i) samples[i].Digits_IfChain();
                sw1.Stop();
                Console.WriteLine($"If-Chain: {sw1.ElapsedMilliseconds} ms");
    
                Stopwatch sw2 = new Stopwatch();
                sw2.Start();
                for (int i = 0; i < size; ++i) samples[i].Digits_Log10();
                sw2.Stop();
                Console.WriteLine($"Log10: {sw2.ElapsedMilliseconds} ms");
    
                Stopwatch sw3 = new Stopwatch();
                sw3.Start();
                for (int i = 0; i < size; ++i) samples[i].Digits_While();
                sw3.Stop();
                Console.WriteLine($"While: {sw3.ElapsedMilliseconds} ms");
    
                Stopwatch sw4 = new Stopwatch();
                sw4.Start();
                for (int i = 0; i < size; ++i) samples[i].Digits_String();
                sw4.Stop();
                Console.WriteLine($"String: {sw4.ElapsedMilliseconds} ms");
            }
    
            // Int64 Performance Tests:
            static void RunTests_Int64()
            {
                Console.WriteLine("\r\nInt64");
    
                const int size = 100000000;
                long[] samples = new long[size];
                Random random = new Random((int)DateTime.Now.Ticks);
                for (int i = 0; i < size; ++i)
                    samples[i] = Math.Sign(random.Next(-1, 1)) * (long)(random.NextDouble() * long.MaxValue);
    
                Stopwatch sw1 = new Stopwatch();
                sw1.Start();
                for (int i = 0; i < size; ++i) samples[i].Digits_IfChain();
                sw1.Stop();
                Console.WriteLine($"If-Chain: {sw1.ElapsedMilliseconds} ms");
    
                Stopwatch sw2 = new Stopwatch();
                sw2.Start();
                for (int i = 0; i < size; ++i) samples[i].Digits_Log10();
                sw2.Stop();
                Console.WriteLine($"Log10: {sw2.ElapsedMilliseconds} ms");
    
                Stopwatch sw3 = new Stopwatch();
                sw3.Start();
                for (int i = 0; i < size; ++i) samples[i].Digits_While();
                sw3.Stop();
                Console.WriteLine($"While: {sw3.ElapsedMilliseconds} ms");
    
                Stopwatch sw4 = new Stopwatch();
                sw4.Start();
                for (int i = 0; i < size; ++i) samples[i].Digits_String();
                sw4.Stop();
                Console.WriteLine($"String: {sw4.ElapsedMilliseconds} ms");
            }
        }
    }
