            var watch = new Stopwatch();
            watch.Start();
            var cnt = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                cnt++;
            }
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
            // takes 00:00:07.8131095
