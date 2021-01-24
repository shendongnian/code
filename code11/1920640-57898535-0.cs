       var times = new List<DateTime>(70000000);
            var sw = new Stopwatch();
            sw.Start();
            DateTime p = new DateTime(1995, 12, 25, 12, 00, 00);
            DateTime end = new DateTime(2005, 12, 25, 12, 00, 00);
            while ( p <= end )
            {
                times.Add(p);
                p = p.AddSeconds(5);
            }
            sw.Stop();
            Console.WriteLine($"{(decimal)sw.ElapsedMilliseconds/1000M} {times.Count} {times.Last()}");
