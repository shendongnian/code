            //var input = "111,222,\"33,44,55\",666,\"77,88\",\"99\"";
            var input =
                "111, 222, \"99\",\"33,44,55\" ,      \"666 \"mark of a man\"\", \" spaces \"77,88\"   \"";
            Console.WriteLine("Split with trim");
            Console.WriteLine("---------------");
            var result = SplitRow(input, ",", "\"", true);
            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
            Console.WriteLine("");
            // Split 2
            Console.WriteLine("Split with no trim");
            Console.WriteLine("------------------");
            var result2 = SplitRow(input, ",", "\"", false);
            foreach (var r in result2)
            {
                Console.WriteLine(r);
            }
            Console.WriteLine("");
            // Time Trial 1
            Console.WriteLine("Experimental Process (1,000,000) iterations");
            Console.WriteLine("-------------------------------------------");
            watch = Stopwatch.StartNew();
            for (var i = 0; i < 1000000; i++)
            {
                var x1 = SplitRow(input, ",", "\"", false);
            }
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Total Process Time: {string.Format("{0:0.###}", elapsedMs / 1000.0)} Seconds");
            Console.WriteLine("");
