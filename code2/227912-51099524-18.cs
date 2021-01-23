    using System;
    using System.Diagnostics;
    
    namespace ConsoleApp2
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                RunPerformaceTest_Int32();
                RunPerformaceTest_Int64();
            }
    
            private static void RunPerformaceTest_Int32()
            {
                Console.WriteLine("\r\nInt32 Performance Test:");
    
                const int size = 100000000;
                int[] samples = new int[size];
                Random random = new Random((int)DateTime.Now.Ticks);
                for (int i = 0; i < size; ++i)
                    samples[i] = random.Next(int.MinValue, int.MaxValue);
    
                Stopwatch sw1 = new Stopwatch();
                sw1.Start();
                for (int i = 0; i < size; ++i) samples[i].Digits1();
                sw1.Stop();
                Console.WriteLine($"{nameof(Int32Extensions.Digits1)}: {sw1.ElapsedMilliseconds} ms");
    
                Stopwatch sw2 = new Stopwatch();
                sw2.Start();
                for (int i = 0; i < size; ++i) samples[i].Digits2();
                sw2.Stop();
                Console.WriteLine($"{nameof(Int32Extensions.Digits2)}: {sw2.ElapsedMilliseconds} ms");
    
                Stopwatch sw3 = new Stopwatch();
                sw3.Start();
                for (int i = 0; i < size; ++i) samples[i].Digits3();
                sw3.Stop();
                Console.WriteLine($"{nameof(Int32Extensions.Digits3)}: {sw3.ElapsedMilliseconds} ms");
    
                Stopwatch sw4 = new Stopwatch();
                sw4.Start();
                for (int i = 0; i < size; ++i) samples[i].Digits4();
                sw4.Stop();
                Console.WriteLine($"{nameof(Int32Extensions.Digits4)}: {sw4.ElapsedMilliseconds} ms");
            }
    
            private static void RunPerformaceTest_Int64()
            {
                Console.WriteLine("\r\nInt64 Performance Test:");
    
                const int size = 100000000;
                long[] samples = new long[size];
                Random random = new Random((int)DateTime.Now.Ticks);
                for (int i = 0; i < size; ++i)
                    samples[i] = Math.Sign(random.Next(-1, 1)) * (long)(random.NextDouble() * long.MaxValue);
    
                Stopwatch sw1 = new Stopwatch();
                sw1.Start();
                for (int i = 0; i < size; ++i) samples[i].Digits1();
                sw1.Stop();
                Console.WriteLine($"{nameof(Int32Extensions.Digits1)}: {sw1.ElapsedMilliseconds} ms");
    
                Stopwatch sw2 = new Stopwatch();
                sw2.Start();
                for (int i = 0; i < size; ++i) samples[i].Digits2();
                sw2.Stop();
                Console.WriteLine($"{nameof(Int32Extensions.Digits2)}: {sw2.ElapsedMilliseconds} ms");
    
                Stopwatch sw3 = new Stopwatch();
                sw3.Start();
                for (int i = 0; i < size; ++i) samples[i].Digits3();
                sw3.Stop();
                Console.WriteLine($"{nameof(Int32Extensions.Digits3)}: {sw3.ElapsedMilliseconds} ms");
    
                Stopwatch sw4 = new Stopwatch();
                sw4.Start();
                for (int i = 0; i < size; ++i) samples[i].Digits4();
                sw4.Stop();
                Console.WriteLine($"{nameof(Int32Extensions.Digits4)}: {sw4.ElapsedMilliseconds} ms");
            }
        }
    }
    
