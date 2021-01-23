            long x = long.MaxValue;
            int lo = (int)(x & 0xffffffff);
            int hi = (int)((x >> 32) & (x & 0xffffffff));
            long y = ((long)hi << 32) | ((long)lo & 0xffffffff);
            Console.WriteLine(System.Convert.ToString(x, 16));
            Console.WriteLine(System.Convert.ToString(lo, 16));
            Console.WriteLine(System.Convert.ToString(hi, 16));
            Console.WriteLine(System.Convert.ToString(y, 16));
