            const int count = 100000;
            var simdVector = new Vector4f(1, 2, 3, 4);
            var sw = Stopwatch.StartNew();
            for(var i = 0; i < count; i++)
            {
                simdVector += simdVector;
            }
            sw.Stop();
            Console.WriteLine("SIMD result: {0}", sw.Elapsed);
            sw = Stopwatch.StartNew();
            var usualVector = new Vector4(1, 2, 3, 4);
            for(var i = 0; i < count; i++)
            {
                usualVector += usualVector;
            }
            sw.Stop();
            Console.WriteLine("Usual result: {0}", sw.Elapsed);
