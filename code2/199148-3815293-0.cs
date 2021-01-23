            var objs = new List<object>(1000000);
            var memUsedStart = GC.GetTotalMemory(true);
            Console.WriteLine("Beginning memory usage = {0:N0}", memUsedStart);
            for (int i = 0; i < 1000000; ++i)
            {
                objs.Add(new object());
            }
            var memUsedEnd = GC.GetTotalMemory(true);
            Console.WriteLine("{0:N0} items in list", objs.Count);
            Console.WriteLine("Ending memory usage = {0:N0}", memUsedEnd);
            var memUsed = memUsedEnd - memUsedStart;
            Console.WriteLine("Difference = {0:N0}", memUsed);
            Console.WriteLine("Bytes per object = {0}", memUsed / 1000000);
            Console.ReadLine();
