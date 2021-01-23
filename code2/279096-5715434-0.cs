        static void Main(string[] args)
        {
            List<double> meansFailedTryParse = new List<double>();
            List<double> meansFailedRegEx = new List<double>();
            List<double> meansSuccessTryParse = new List<double>();
            List<double> meansSuccessRegEx = new List<double>();
            for (int i = 0; i < 1000; i++)
            {
                string input = "123abc";
                int res;
                bool res2;
                var sw = Stopwatch.StartNew();
                res2 = Int32.TryParse(input, out res);
                sw.Stop();
                meansFailedTryParse.Add(sw.Elapsed.TotalMilliseconds);
                //Console.WriteLine("Result of " + res2 + " try parse :" + sw.Elapsed.TotalMilliseconds);
                sw = Stopwatch.StartNew();
                res2 = Regex.IsMatch(input, @"^[0-9]*$");
                sw.Stop();
                meansFailedRegEx.Add(sw.Elapsed.TotalMilliseconds);
                //Console.WriteLine("Result of " + res2 + "  Regex.IsMatch :" + sw.Elapsed.TotalMilliseconds);
                input = "123";
                sw = Stopwatch.StartNew();
                res2 = Int32.TryParse(input, out res);
                sw.Stop();
                meansSuccessTryParse.Add(sw.Elapsed.TotalMilliseconds);
                //Console.WriteLine("Result of " + res2 + " try parse :" + sw.Elapsed.TotalMilliseconds);
                sw = Stopwatch.StartNew();
                res2 = Regex.IsMatch(input, @"^[0-9]*$");
                sw.Stop();
                meansSuccessRegEx.Add(sw.Elapsed.TotalMilliseconds);
                //Console.WriteLine("Result of " + res2 + "  Regex.IsMatch :" + sw.Elapsed.TotalMilliseconds);
            }
            Console.WriteLine("Failed TryParse mean execution time     " + meansFailedTryParse.Average());
            Console.WriteLine("Failed Regex mean execution time        " + meansFailedRegEx.Average());
            Console.WriteLine("successful TryParse mean execution time " + meansSuccessTryParse.Average());
            Console.WriteLine("successful Regex mean execution time    " + meansSuccessRegEx.Average());
        }
    }
