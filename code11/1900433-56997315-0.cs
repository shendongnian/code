        static void second()
        {
            var watch1 = new System.Diagnostics.Stopwatch();
            watch1.Start();
            var a = fibonacciRecursive(50);
            watch1.Stop();
            Console.WriteLine(a);
            Console.WriteLine($"Execution Time: {watch1.ElapsedMilliseconds} ms");
        }
