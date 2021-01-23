            int numTests = 10000;
            double sum = 0;
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < numTests; ++i)
            {
                var d = Convert.ToDouble("1.23456");
                sum += d;
            }
            sw.Stop();
            Console.WriteLine("{0} tests @ {1} ms. Avg of {2:N4} ms each", numTests,
               sw.ElapsedMilliseconds, (double)sw.ElapsedMilliseconds/numTests);
            Console.WriteLine("sum = {0}", sum);
