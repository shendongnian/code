            int numLongs = 1000000;
            int numInts = 2*numLongs;
            var longs = new long[numLongs];
            var ints = new int[numInts];
            Random rnd = new Random();
            // generate values
            for (int i = 0; i < numLongs; ++i)
            {
                int i1 = rnd.Next();
                int i2 = rnd.Next();
                ints[2 * i] = i1;
                ints[2 * i + 1] = i2;
                long l = i1;
                l = (l << 32) | (uint)i2;
                longs[i] = l;
            }
            // time operations.
            int isum = 0;
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < numInts; i += 2)
            {
                isum += ints[i] & ints[i + 1];
            }
            sw.Stop();
            Console.WriteLine("Ints: {0} ms. isum = {1}", sw.ElapsedMilliseconds, isum);
            long lsum = 0;
            int halfLongs = numLongs / 2;
            sw.Restart();
            for (int i = 0; i < halfLongs; i += 2)
            {
                lsum += longs[i] & longs[i + 1];
            }
            sw.Stop();
            Console.WriteLine("Longs: {0} ms. lsum = {1}", sw.ElapsedMilliseconds, lsum);
