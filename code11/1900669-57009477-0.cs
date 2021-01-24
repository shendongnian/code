    var Stopwatch = new Stopwatch();
            var input = Convert.ToInt32(Console.ReadLine());
            Stopwatch.Start();
            double res = 1.0;
            input = input * -1;
            for (int i = input; i < 0; i++)
            {
                res += Math.Pow(10, i);
            }
            Console.WriteLine(res);
            Stopwatch.Stop();
            TimeSpan ts = Stopwatch.Elapsed;
