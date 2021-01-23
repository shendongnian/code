            const int count = 100000;
            var simdVector = new Vector4f(1, 2, 3, 4);
            var simdResult = simdVector;
            var sw = Stopwatch.StartNew();
            for(var i = 0; i < count; i++)
            {
                simdResult += simdVector;
            }
            sw.Stop();
            Console.WriteLine("SIMD  result: {0} {1}", sw.Elapsed, simdResult);
            sw = Stopwatch.StartNew();
            var usualVector = new Vector4(1, 2, 3, 4);
            var usualResult = usualVector;
            for(var i = 0; i < count; i++)
            {
                usualResult += usualVector;
            }
            sw.Stop();
            Console.WriteLine("Usual result: {0} {1}", sw.Elapsed, usualResult);
