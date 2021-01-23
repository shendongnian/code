            var mult = 255.0 / Math.Log(255, 45);
            Console.WriteLine("Scaling factor is {0}", mult);
            double errMax = double.MinValue;
            double errMin = double.MaxValue;
            double errTot = 0;
            for (int i = 1; i < 256; ++i)
            {
                // Get the log of the number you want
                var l = Math.Log(i, 45);
                // Convert to byte
                var b = (byte)(l * mult);
                // Now go back the other way.
                var a = Math.Pow(45, (double)b / mult);
                var err = (double)(i - a) / i;
                errTot += err;
                errMax = Math.Max(errMax, err);
                errMin = Math.Min(errMin, err);
                Console.WriteLine("{0,3:N0}, {1,3:N0}, {2}, {3:P4}", i, b, a, err);
            }
            Console.WriteLine("max error = {0:P4}", errMax);
            Console.WriteLine("min error = {0:P4}", errMin);
            Console.WriteLine("avg error = {0:P4}", errTot / 255);
